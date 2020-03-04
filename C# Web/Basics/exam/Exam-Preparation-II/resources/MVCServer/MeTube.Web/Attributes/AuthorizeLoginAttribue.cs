using SimpleMvc.Framework.Attributes.Security;
using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Http.Contracts;
using WebServer.Http.Response;

namespace MeTubeApp.Web.Attributes
{
    public class AuthorizeLoginAttribute : PreAuthorizeAttribute
    {
        public override IHttpResponse GetResponse(string message)
        {
            return new RedirectResponse("/users/login");
        }
    }
}
