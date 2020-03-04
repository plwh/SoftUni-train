namespace MeTubeApp.Web
{
    using MeTubeApp.Data;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using System;
    using WebServer;

    public class Launcher
    {
        static void Main(string[] args)
        {
            var context = new MeTubeAppContext();

            var server = new WebServer(
                42421,
                new ControllerRouter(),
                new ResourceRouter());

            MvcEngine.Run(server, context);
        }
    }
}
