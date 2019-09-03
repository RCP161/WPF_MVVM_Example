using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Common;
using Company.App.Core.Logic.Basic;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories;

namespace Company.Project
{
    internal class TestData
    {
        internal TestData()
        {
            TestOrCreatePersons();
        }

        private void TestOrCreatePersons()
        {
            CreatePersons();
            CreatePermissions();



        }

        private void CreatePersons()
        {
            IPersonService service = ServiceLocator.Default.ResolveType<IPersonService>();
            int c = service.GetCount();

            if(c > 5)
                return;

            Company.App.Core.Models.Basic.Person p;
            for(int i = 0; i < 5; i++)
            {
                p = new Company.App.Core.Models.Basic.Person();
                p.Name = "Person";
                p.Surename = Guid.NewGuid().ToString();

                p.SaveModel();
            }
        }

        private void CreatePermissions()
        {
            IPermissionService service = ServiceLocator.Default.ResolveType<IPermissionService>();
            int c = service.GetCount();

            if(c > 0)
                return;

            Company.App.Core.Models.Security.Permission p = new Company.App.Core.Models.Security.Permission();
            p.Name = "Person";

            // TODO : Hier geht's weiter
            // Voll Falsch. Ein Recht hat einen Namen und vll eine Beschreibung.
            // Gruppen haben Rechte, plus die Einstellung dazu, welche (Read Write)
            // Read Write ist also am falschen Objekt und ein Recht braucht keine Gruppe ...
        }
    }
}
