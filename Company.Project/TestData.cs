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
                p = new Person(true);
                p.Name = "Person";
                p.Surename = Guid.NewGuid().ToString();

                p.Save();
            }
        }

        private void CreatePermissions()
        {
            IPermissionService service = ServiceLocator.Default.ResolveType<IPermissionService>();
            int c = service.GetCount();

            if(c > 0)
                return;

            Permission p = new Permission(true);
            p.Name = "Person";
            p.Comment = "Recht zum sehen und bearbeiten von Personen";
            p.Save();

            Permission g = new Permission(true);
            g.Name = "Group";
            g.Comment = "Recht zum sehen und bearbeiten von Gruppen";
            g.Save();

            Permission u = new Permission(true);
            u.Name = "User";
            u.Comment = "Recht zum sehen und bearbeiten von LogIn-Usern";
            u.Save();

            // Gruppe 1
            Group grp = new Group(true);
            grp.Name = "KeyUser";
            grp.GroupPermissions = new System.Collections.ObjectModel.ObservableCollection<GroupPermission>();

            GroupPermission gp = new GroupPermission(true);
            gp.Permission = p;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            gp = new GroupPermission(true);
            gp.Permission = g;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            gp = new GroupPermission(true);
            gp.Permission = u;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            grp.Save();


            // Gruppe 2
            grp = new Group(true);
            grp.Name = "Verwaltung";
            grp.GroupPermissions = new System.Collections.ObjectModel.ObservableCollection<GroupPermission>();

            gp = new GroupPermission(true);
            gp.Permission = p;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            grp.Save();


            // Gruppe 3
            grp = new Group(true);
            grp.Name = "Facharbeiter";
            grp.Save();


            IPersonService personService = ServiceLocator.Default.ResolveType<IPersonService>();

            User user = new User(true);
            user.LogIn = "KeyUser";
            user.Password = "Password";
            user.Person = personService.GetAll().First(); // Eig falsch, aber das ist hier für Testdaten egal. Eig eigene Funktion
            user.Save();

            user = new User(true);
            user.LogIn = "Sandra";
            user.Password = "Mustermann";
            user.Save();
        }
    }
}
