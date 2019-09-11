using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Company.App.Core.Common;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSource.Repositories.App;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Basic;

namespace Company.App.DataSource.Repositories.Basic
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public IEnumerable<User> GetByGroupId(int id)
        {
            return DataAccess.Query<User>().Where(x => x.Groups.Any(y => y.Id == id)).ToList();
        }

        public Person GetByIdForEdit(int id)
        {
            Person p = DataAccess.GetById<Person>(id);
            p.User = DataAccess.Query<User>().Where(x => x.Person.Id == id).FirstOrDefault();
            return p;
        }
    }
}
