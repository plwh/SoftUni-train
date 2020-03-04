using MeTubeApp.Data;
using MeTubeApp.Models;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeTubeApp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new MeTubeAppContext();
            this.Model.Data["error"] = string.Empty;
        }

        protected MeTubeAppContext Context { get; set; }

        protected User DbUser { get; private set; }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");

        public override void OnAuthentication()
        {
            this.Model.Data["topMenu"] = this.User.IsAuthenticated ?
                @" <li class=""nav-item active col-md-3"">
	                <a class=""nav-link h5"" href=""/"">Home</a>
                </li>
                <li class=""nav-item active col-md-3"">
	                <a class=""nav-link h5"" href=""/users/profile"">Profile</a>
                </li>
                <li class=""nav-item active col-md-3"">
	                <a class=""nav-link h5"" href=""/tubes/upload"">Upload</a>
                </li>
                <li class=""nav-item active col-md-3"">
	                <a class=""nav-link h5"" href=""/users/logout"">Logout</a>
                </li>"
                        :
                @" <li class=""nav-item active col-md-4"">
	                <a class=""nav-link h5"" href=""/"">Home</a>
                </li>
                <li class=""nav-item active col-md-4"">
	                <a class=""nav-link h5"" href=""/users/login"">Login</a>
                </li>
                <li class=""nav-item active col-md-4"">
	                <a class=""nav-link h5"" href=""/users/register"">Register</a>
                </li>";

            if(this.User.IsAuthenticated)
            {
                this.DbUser = this.Context.Users
                    .FirstOrDefault(u => u.Username == this.User.Name); 
            }

            base.OnAuthentication();
        }

        protected virtual IActionResult BuildErrorView()
        {
            this.Model.Data["error"] = "You have errors in your form.";
            return this.View();
        }
    }
}
