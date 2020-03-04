using MeTubeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeTubeApp.Web.Models.ViewModels
{
    public class TubeIndexViewModel
    {
        public string YouTubeId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public static Func<Tube, TubeIndexViewModel> FromTube =>
            tube => new TubeIndexViewModel()
            {
                YouTubeId = tube.YouTubeId,
                Author = tube.Author,
                Title = tube.Title
            };
    }
}
