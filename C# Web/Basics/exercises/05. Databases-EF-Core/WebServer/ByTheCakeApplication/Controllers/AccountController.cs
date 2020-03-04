namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Linq;
    using HTTPServer.ByTheCakeApplication.Data;
    using HTTPServer.ByTheCakeApplication.Utilities;
    using HTTPServer.Server.Common;
    using Infrastructure;
    using Models;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class AccountController : Controller
    {
        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\register");
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formUsernameKey = "username";
            const string formPasswordKey = "password";
            const string formConfirmPasswordKey = "confirm-password";

            if (!req.FormData.ContainsKey(formNameKey) ||
                !req.FormData.ContainsKey(formUsernameKey) ||
                !req.FormData.ContainsKey(formPasswordKey) ||
                !req.FormData.ContainsKey(formConfirmPasswordKey))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"account\register");
            }

            string name = req.FormData[formNameKey];
            string username = req.FormData[formUsernameKey];
            string password = req.FormData[formPasswordKey];
            string confirmPassword = req.FormData[formConfirmPasswordKey];

            try
            {
                CoreValidator.ThrowIfNotLongEnough(name, "name", 3);
                CoreValidator.ThrowIfNotLongEnough(username, "username", 3);
                CoreValidator.ThrowIfNullOrEmpty(password, "password");
                CoreValidator.ThrowIfNotEqualStrings(password, confirmPassword, "password", "confirmPassword");
            }
            catch(ArgumentException)
            {
                this.ViewData["error"] = "You have wrong fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"account\register");
            }

            var user = new User()
            {
                Name = req.FormData[formNameKey],
                Username = req.FormData[formUsernameKey],
                PasswordHash = PasswordUtilities.ComputeHash(password),
                RegistrationDate = DateTime.UtcNow
            };

            using (this.Context)
            {
                this.Context.Users.Add(user);
                this.Context.SaveChanges();
            }

            return CompleteLogin(req, user.Id);
        }

        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey)
                || !req.FormData.ContainsKey(formPasswordKey))
            {
                return new BadRequestResponse();
            }

            var name = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"account\login");
            }

            User dbUser = null;
            using (this.Context)
            {
                dbUser = this.Context.Users.FirstOrDefault(user => user.Username == name);
            }

            if (dbUser == null)
            {
                return this.RejectLoginAttempt();
            }

            string passwordHash = PasswordUtilities.ComputeHash(password);
            if (passwordHash != dbUser.PasswordHash)
            {
                return this.RejectLoginAttempt();
            }

            return CompleteLogin(req, dbUser.Id);
        }
        
        public IHttpResponse Profile(IHttpRequest req)
        {
            int currentUserId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            User currentUser = null;
            using (this.Context)
            {
                currentUser = this.Context.Users.Find(currentUserId);
            }

            this.ViewData["name"] = currentUser.Name;
            this.ViewData["registrationDate"] = currentUser.RegistrationDate.ToString("dd-MM-yyyy");
            this.ViewData["ordersCount"] = currentUser.Orders.Count.ToString();

            return this.FileViewResponse(@"account\profile");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }

        private IHttpResponse RejectLoginAttempt()
        {
            this.ViewData["error"] = "There is no such user";
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "none";
            return this.FileViewResponse(@"account\login");
        }

        private static IHttpResponse CompleteLogin(IHttpRequest req, int userId)
        {
            req.Session.Add(SessionStore.CurrentUserKey, userId);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }
    }
}
