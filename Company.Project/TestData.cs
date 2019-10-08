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
            IEnumerable<string> conflicts = new List<string>();


            for(int i = 0; i <= 5; i++)
            {
                p = new Person();
                p.Name = "Person";
                p.Surename = Guid.NewGuid().ToString();

                if(!service.TrySave(p, conflicts))
                    throw new Exception();
            }
        }

        private void CreatePermissions()
        {
            IUserService userService = ServiceLocator.Default.ResolveType<IUserService>();
            IGroupService groupService = ServiceLocator.Default.ResolveType<IGroupService>();
            IPermissionService permissionService = ServiceLocator.Default.ResolveType<IPermissionService>();
            int c = permissionService.GetCount();

            if(c > 0)
                return;

            IEnumerable<string> conflicts = new List<string>();

            Permission p = new Permission();
            p.Name = "Person";
            p.Comment = "Recht zum sehen und bearbeiten von Personen";

            if(!permissionService.TrySave(p, conflicts))
                throw new Exception();

            Permission g = new Permission();
            g.Name = "Group";
            g.Comment = "Recht zum sehen und bearbeiten von Gruppen";

            if(!permissionService.TrySave(p, conflicts))
                throw new Exception();

            Permission u = new Permission();
            u.Name = "User";
            u.Comment = "Recht zum sehen und bearbeiten von LogIn-Usern";

            if(!permissionService.TrySave(p, conflicts))
                throw new Exception();

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

            if(!groupService.TrySave(grp, conflicts))
                throw new Exception();


            // Gruppe 2
            grp = new Group();
            grp.Name = "Verwaltung";

            gp = new GroupPermission();
            gp.Permission = p;
            gp.Write = true;
            grp.GroupPermissions.Add(gp);

            if(!groupService.TrySave(grp, conflicts))
                throw new Exception();


            // Gruppe 3
            grp = new Group();
            grp.Name = "Facharbeiter";

            if(!groupService.TrySave(grp, conflicts))
                throw new Exception();


            IPersonService personService = ServiceLocator.Default.ResolveType<IPersonService>();

            User user = new User();
            user.LogIn = "KeyUser";
            user.Password = "Password";
            user.Person = personService.GetAll().First(); // Eig falsch, aber das ist hier für Testdaten egal. Eig eigene Funktion

            if(!userService.TrySave(user, conflicts))
                throw new Exception();

            user = new User();
            user.LogIn = "Sandra";
            user.Password = "Mustermann";

            if(!userService.TrySave(user, conflicts))
                throw new Exception();
        }
    }
}
