namespace HTTPServer.GameStoreApplication.Controllers
{
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Infrastructure;

    public class AccountController : Controller
    {
        public IHttpResponse Register() => this.FileViewResponse("account/register");
    }
}
