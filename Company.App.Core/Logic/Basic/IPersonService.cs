using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Logic.App;
using Company.App.Core.Models.Basic;

namespace Company.App.Core.Logic.Basic
{
    public interface IPersonService : IModelBase2Service<Person>, ISaveableService<Person>
    {
        Person GetByIdForEdit(int id);
    }
}
