using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Contracts
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}
