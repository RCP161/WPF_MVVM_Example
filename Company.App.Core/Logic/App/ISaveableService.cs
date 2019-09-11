using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Common;
using Company.App.Core.Models;

namespace Company.App.Core.Logic.App
{
    public interface ISaveableService<T> where T : ModelBase2<T>
    {
        // Könnte man zu IEditable machen. Muss aber am Repo dann trotzdem ModelBase2 sein, weil eine Klasse verlangt wird
        public void Save(T model, IDataAccess dataAccess);
    }
}
