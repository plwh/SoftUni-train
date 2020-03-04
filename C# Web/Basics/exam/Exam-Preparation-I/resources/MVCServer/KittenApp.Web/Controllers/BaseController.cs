namespace KittenApp.Web.Controllers
{
    using KittenApp.Data;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new KittenAppContext();
        }

        protected KittenAppContext Context { get; set; }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");
    }
}
