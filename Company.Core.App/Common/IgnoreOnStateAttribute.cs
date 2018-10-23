using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.App.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IgnoreOnStateAttribute : Attribute
    {
        public IgnoreOnStateAttribute()
        {

        }
    }
}
