using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSource.Common;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace Company.App.DataSource.Repositories.Basic
{
    public class PersonRepository : IPersonRepository
    {
        internal PersonRepository(EfContext dataAccess)
        {
            DataAccess = dataAccess;
        }

        protected EfContext DataAccess { get; private set; }

        public IEnumerable<User> GetByGroupId(int id)
        {
            return DataAccess.Query<User>().Where(x => x.Groups.Any(y => y.Id == id)).ToList();
        }

        public Person GetByIdForEdit(int id)
        {
            return DataAccess.Query<Person>().Where(x => x.Id == id).Include(x => x.User).FirstOrDefault();
        }
    }
}
