﻿using MeTubeApp.Web.Models.ViewModels;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeTubeApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                var tubes = this.Context.Tubes
                    .Select(TubeIndexViewModel.FromTube)
                    .ToList();

                var tubesResult = new StringBuilder();
                tubesResult.Append(@"<div class=""row text - center"">");
                for (int i = 0; i < tubes.Count; i++)
                {
                    var tube = tubes[i];
                    tubesResult.Append($@"<div class=""col-4"">
                                        <img class=""img-thumbnail tube-thumbnail"" src=""https://img.youtube.com/vi/{tube.YouTubeId}/0.jpg"" alt=""{tube.Title}"" />
                                        <div>
                                            <h5>{tube.Title}</h5>
                                            <h5>{tube.Author}</h5>
                                        </div>
                                        </div>");
                    if(i % 3 == 2)
                    {
                        tubesResult.Append(@"</div><div class=""row text - center"">");
                    }
                }
                tubesResult.Append("</div>");

                this.Model.Data["result"] = tubesResult.ToString();
            }
            else
            {
                this.Model.Data["result"] =
                    @"<hr class=""my-3""/>
                        <div class=""jumbotron"">
                            <p class=""h1 display-3"">Welcome to MeTube&trade;!</p>
                            <p class=""h3"">The simplest, easiest to use, most comfortable Multimedia Application.</p>
                            <hr class=""my-3"">
                            <p><a href=""/login"">Login</a> if you have an account or <a href=""/register"">Register</a> now and start tubing.</p>
                        </div>";
            }

            return this.View();
        }
    }
}
