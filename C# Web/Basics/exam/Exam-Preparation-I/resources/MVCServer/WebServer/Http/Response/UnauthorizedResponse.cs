using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Enums;

namespace WebServer.Http.Response
{
    public class UnauthorizedResponse : HttpResponse
    {
        public UnauthorizedResponse()
        {
            this.StatusCode = HttpStatusCode.Unauthorized;
            // TODO: Add message
        }
    }
}
