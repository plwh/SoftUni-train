using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Contracts
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}
