using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.DataSourceDefinition.Common
{
    public interface IDbConfigruation
    {
        string ConnectionString { get; }
    }
}
