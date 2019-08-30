using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Basic;

namespace Company.App.DataSource.Repositories.Basic
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
