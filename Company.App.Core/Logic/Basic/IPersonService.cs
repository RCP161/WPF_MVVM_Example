using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;

namespace Company.App.Core.Logic.Basic
{
    public interface IPersonService
    {
        IEnumerable<Person> LoadPersons();
    }
}
