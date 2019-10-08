using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.Core.Logic
{
    public interface ModelBase2Service<T> where T : ModelBase2
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        int GetCount();

        bool IsDeleteAllowed(T model, IEnumerable<string> conflicts);

        bool TryDelete(T model, IEnumerable<string> conflicts);

        bool Validate(T model, IEnumerable<string> conflicts);

        bool TrySave(T model, IEnumerable<string> conflicts);
    }
}
