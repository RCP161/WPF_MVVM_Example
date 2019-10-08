using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Repositories.Security
{
    public class UserRepository : ModelBase2Repository<User>, IUserRepository
    {
        internal UserRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public IEnumerable<User> GetByGroupId(int id)
        {
            return DataAccess.Query<User>().Where(x => x.Groups.Any(y => y.Id == id)).ToList();
        }

        public User GetByPersonId(int id)
        {
            return DataAccess.Query<User>().Where(x => x.Person.Id == id).FirstOrDefault();
        }
    }
}
