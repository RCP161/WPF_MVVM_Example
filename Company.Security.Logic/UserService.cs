using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models.Security;
using Company.App.Logic;

namespace Company.Security.Logic
{
    public class UserService : ModelBase2Service<User>, IUserService
    {
    }
}
