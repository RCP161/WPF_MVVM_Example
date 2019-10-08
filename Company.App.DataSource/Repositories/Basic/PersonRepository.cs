using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Basic;

namespace Company.App.DataSource.Repositories.Basic
{
    public class PersonRepository : ModelBase2Repository<Person>, IPersonRepository
    {
        internal PersonRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public Person GetByIdForEdit(int id)
        {
            Person person = DataAccess.Query<Person>().Where(x => x.Id == id).FirstOrDefault();

            if(person == null)
                return null;

            person.User = DataAccess.Query<User>().Where(x => x.Person.Id == id).FirstOrDefault();

            return person;
        }
    }
}
