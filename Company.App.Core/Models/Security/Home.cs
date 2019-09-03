using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.IoC;

namespace Company.App.Core.Models.Security
{
    public class Home : ModelBase1
    {
        public Home()
        {
            //Users = new ObservableCollection<User>(ServiceLocator.Default.ResolveType<Logic.Basic.IUserService>().LoadUsers());
        }

        #region Properties

        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));

        public ObservableCollection<Group> Groups
        {
            get { return GetValue<ObservableCollection<Group>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Groups), typeof(ObservableCollection<Group>));


        #endregion

        #region Methods

        public void OpenUser(User user)
        {
            // Rechte, etc.
            ServiceLocator.Default.ResolveType<Logic.Project.IMainUiService>().SetMainContent(user);
        }

        public void OpenGroup(Group group)
        {
            // Rechte, etc.
            ServiceLocator.Default.ResolveType<Logic.Project.IMainUiService>().SetMainContent(group);
        }

        #endregion
    }
}
