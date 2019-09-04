using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.Core.Logic
{
    public interface IModelBase2Service<T> where T : ModelBase2
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        int GetCount();
    }
}
