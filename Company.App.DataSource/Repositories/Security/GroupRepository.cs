﻿using System;
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
    public class GroupRepository : ModelBase2Repository<Group>, IGroupRepository
    {
        internal GroupRepository(IDataAccess dataAccess) : base(dataAccess)
        { }


        public IEnumerable<Group> GetByUserId(int id)
        {
            return DataAccess.Query<Group>().Where(x => x.Users.Any(y => y.Id == id)).ToList();
        }
    }
}
