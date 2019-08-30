using System;
using System.Collections.Generic;
using System.Text;
using Company.Project.Core.Models.Basic;

namespace Company.Project.Core.Logic.Basic
{
    public interface IPersonService
    {
        IEnumerable<Person> LoadPersons();
    }
}
