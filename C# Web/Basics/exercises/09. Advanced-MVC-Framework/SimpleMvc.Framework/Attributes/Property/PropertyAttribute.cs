using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Attributes.Property
{
    public abstract class PropertyAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}
