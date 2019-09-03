using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.Core.Logic.App
{
    public interface ISaveableService
    {
        public void Save<T>(T model) where T : ModelBase2;
    }
}
