﻿using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;
using Company.App.Logic;

namespace Company.Security.Logic
{
    public class GroupService : ModelBase2Service<Group>, IGroupService
    {
        public IEnumerable<Group> GetByUserId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupRepository.GetByUserId(id);
            }
        }
    }
}
