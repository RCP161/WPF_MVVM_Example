using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.Core.Logic.App
{
    public interface ISaveableService
    {
        // Könnte man zu IEditable machen. Muss aber am Repo dann trotzdem ModelBase2 sein, weil eine Klasse verlangt wird
        public void Save<T>(T model) where T : ModelBase2;
    }
}
