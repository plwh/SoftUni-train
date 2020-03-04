using SimpleMvc.Framework.ActionResults;
using SimpleMvc.Framework.Attributes.Property;
using SimpleMvc.Framework.Contracts;
using SimpleMvc.Framework.Models;
using SimpleMvc.Framework.Security;
using SimpleMvc.Framework.Views;
using System.Linq;
using System.Runtime.CompilerServices;
using WebServer.Http;
using WebServer.Http.Contracts;

namespace SimpleMvc.Framework.Controllers
{
    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        protected ViewModel Model { get; set; }

        protected internal IHttpRequest Request { get; internal set; }

        protected internal Authentication User { get; private set; }

        protected internal void InitializeController()
        {
            var user = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            if(user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.InitializeViewModelData();

            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            var fullyQualifiedName = string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            IRenderable view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected bool IsValidModel(object bindingModel)
        {
            var properties = bindingModel.GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyAttributes = property
                    .GetCustomAttributes(true)
                    .Where(ca => ca is PropertyAttribute);

                if(!propertyAttributes.Any())
                {
                    continue;
                }

                foreach (PropertyAttribute propertyAttribute in propertyAttributes)
                {
                    if (!propertyAttribute.IsValid(bindingModel))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void InitializeViewModelData()
        {
            this.Model["displayType"] = this.User.IsAuthenticated ? "block" : "none";
        }
    }
}
