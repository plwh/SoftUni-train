using System;
using HTTPServer.GameStoreApplication.Controllers;
using HTTPServer.Server.Contracts;
using HTTPServer.Server.Routing.Contracts;

namespace HTTPServer.GameStoreApplication
{
    public class GameStoreApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            this.ConfigureRoutes(appRouteConfig);
            this.ConfigureDatabase();
        }

        private void ConfigureRoutes(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig                          
                .Get("/register",
                  req => new AccountController().Register());
        }

        private void ConfigureDatabase()
        {
           
        }
    }
}
