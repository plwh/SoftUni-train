namespace KittenApp.Web.Controllers
{
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if(this.User.IsAuthenticated)
            {
                this.Model.Data["message"] = $"Welcome, {this.User.Name}!";
            }
            else
            {
                this.Model.Data["message"] = "Welcome to Fluffy Duffy Munchkin Cats";
            }
            return this.View();
        }
    }
}
