using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.DataSourceDefinition.Common
{
    public interface IDbConfigruation
    {
        string ConnectionString { get; }
    }
}
