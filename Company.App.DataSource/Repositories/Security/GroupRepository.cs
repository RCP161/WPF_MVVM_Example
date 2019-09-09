using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSource.Common;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Repositories.Security
{
    public class GroupRepository : IGroupRepository
    {
        internal GroupRepository(EfContext dataAccess)
        {
            DataAccess = dataAccess;
        }

        protected EfContext DataAccess { get; private set; }


        public IEnumerable<Group> GetByUserId(int id)
        {
            return DataAccess.Query<Group>().Where(x => x.Users.Any(y => y.Id == id)).ToList();
        }
    }
}
