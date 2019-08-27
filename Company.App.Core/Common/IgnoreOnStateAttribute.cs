using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IgnoreOnStateAttribute : Attribute
    {
        public IgnoreOnStateAttribute()
        {

        }
    }
}
