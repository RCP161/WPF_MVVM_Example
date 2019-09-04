using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Catel.IoC;
using Company.App.Core.Common;
using Company.App.Core.Logic.Basic;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
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

            Person p;
            for(int i = 0; i <= 5; i++)
            {
                p = new Person();
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

            Permission p = new Permission();
            p.Name = "Person";
            p.Comment = "Recht zum sehen und bearbeiten von Personen";
            p.SaveModel();

            Permission g = new Permission();
            g.Name = "Group";
            g.Comment = "Recht zum sehen und bearbeiten von Gruppen";
            g.SaveModel();

            Permission u = new Permission();
            u.Name = "User";
            u.Comment = "Recht zum sehen und bearbeiten von LogIn-Usern";
            u.SaveModel();

            // Gruppe 1
            Group grp = new Group();
            grp.Name = "KeyUser";

            GroupPermission gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = g;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            gp = new GroupPermission();
            gp.Permission = u;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            grp.SaveModel();


            // Gruppe 2
            grp = new Group();
            grp.Name = "Verwaltung";

            gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            grp.SaveModel();


            // Gruppe 3
            grp = new Group();
            grp.Name = "Facharbeiter";
            grp.SaveModel();


            IPersonService personService = ServiceLocator.Default.ResolveType<IPersonService>();

            User user = new User();
            user.LogIn = "KeyUser";
            user.Password = "Password";
            user.Person = personService.GetAll().First(); // Eig falsch, aber das ist hier für Testdaten egal. Eig eigene Funktion
            user.SaveModel();

            user = new User();
            user.LogIn = "Sandra";
            user.Password = "Mustermann";
            user.SaveModel();
        }
    }
}
