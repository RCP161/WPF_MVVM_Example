using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.App.Core.Models.Security;

namespace Company.Security.Presentation
{
    public class HomeVm : ViewModelBase
    {
        public HomeVm(Home home)
        {
            Model = home;
            OpenGroupCommand = new Command(() => Model.OpenGroup(SelectedGroup));
            OpenUserCommand = new Command(() => Model.OpenUser(SelectedUser));
        }

        #region Properties

        [Model]
        public Home Model
        {
            get { return GetValue<Home>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Home));


        [ViewModelToModel]
        public ObservableCollection<Group> Groups
        {
            get { return GetValue<ObservableCollection<Group>>(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }
        public static readonly PropertyData GroupsProperty = RegisterProperty(nameof(Groups), typeof(ObservableCollection<Group>));


        public Group SelectedGroup
        {
            get { return GetValue<Group>(SelectedGroupProperty); }
            set { SetValue(SelectedGroupProperty, value); }
        }
        public static readonly PropertyData SelectedGroupProperty = RegisterProperty(nameof(SelectedGroup), typeof(Group));


        [ViewModelToModel]
        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));


        public User SelectedUser
        {
            get { return GetValue<User>(SelectedUserProperty); }
            set { SetValue(SelectedUserProperty, value); }
        }
        public static readonly PropertyData SelectedUserProperty = RegisterProperty(nameof(SelectedUser), typeof(User));

        public Command OpenGroupCommand { get; private set; }
        public Command OpenUserCommand { get; private set; }

        #endregion
    }
}
