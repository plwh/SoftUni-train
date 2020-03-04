using Microsoft.EntityFrameworkCore;
using SimpleMvc.App.BindingModels;
using SimpleMvc.Data;
using SimpleMvc.Domain;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;
using SimpleMvc.Framework.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMvc.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel registerUserBinding)
        {
            if(!this.IsValidModel(registerUserBinding))
            {
                return View();
            }

            var user = new User()
            {
                Username = registerUserBinding.Username,
                PasswordHash = registerUserBinding.Password
            };

            using(var context = new SimpleMvcDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel loginUserBinding)
        {
            using (var context = new SimpleMvcDbContext())
            {
                var foundUser = context.Users.FirstOrDefault(u => u.Username == loginUserBinding.Username);

                if (foundUser == null)
                {
                    return RedirectToAction("/home/login");
                }

                context.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return RedirectToAction("/home/index");
        }
        
        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/users/login");
            }

            Dictionary<int, string> users = new Dictionary<int, string>();

            using (var context = new SimpleMvcDbContext())
            {
                users = context.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            this.Model["users"] =
                users.Any() ? string.Join(string.Empty, users
                                                        .Select(u => $"<li><a href=\"/users/profile?id={u.Key}\">{u.Value}</a></li>"))
                : string.Empty;

            return View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            User user = null;

            using (var context = new SimpleMvcDbContext())
            {
                user = context.Users
                    .Include(u => u.Notes)
                    .SingleOrDefault(u => u.Id == id);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Profile(AddNoteBindingModel model)
        {
            using (var context = new SimpleMvcDbContext())
            {
                var user = context.Users.Find(model.UserId);
                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();
            }

            return Profile(model.UserId);
        }
    }
}
