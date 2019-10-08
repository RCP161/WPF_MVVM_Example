using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;

namespace Company.App.Core.Logic.Security
{
    public interface IGroupService : ModelBase2Service<Group>
    {
        IEnumerable<Group> GetByUserId(int id);
    }
}
