using System;
using System.Collections.Generic;
using System.Text;
using Company.Project.Core.Models.Basic;
using Company.Project.DataSourceDefinition.Common;
using Company.Project.DataSourceDefinition.Repositories.Basic;

namespace Company.Project.DataSource.Repositories.Basic
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public override Person GetCompleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
