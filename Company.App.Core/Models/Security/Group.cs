using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.App.Core.Models;

namespace Company.App.Core.Models.Security
{
    [Table("Group")]
    public class Group : ModelBase2
    {
        public Group() : base(true)
        { }

        public Group(bool isNew) : base(isNew)
        { }

        #region Properties

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id
        {
            get { return GetValue<int>(IdProperty); }
            protected set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int));


        [Required, MaxLength(255)]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        public ObservableCollection<GroupPermission> GroupPermissions
        {
            get
            {
                ObservableCollection<GroupPermission> list = GetValue<ObservableCollection<GroupPermission>>(GroupPermissionsProperty);

                if(list == null)
                    list = new ObservableCollection<GroupPermission>(ServiceLocator.Default.ResolveType<Logic.Security.IGroupPermissionService>().GetByGroupId(Id));

                return list;
            }
            set { SetValue(GroupPermissionsProperty, value); }
        }

        public static readonly PropertyData GroupPermissionsProperty = RegisterProperty(nameof(GroupPermissions), typeof(ObservableCollection<GroupPermission>));


        public IList<UserGroups> UserGroups { get; set; }

        [NotMapped]
        public ObservableCollection<User> Users
        {
            get
            {
                ObservableCollection<User> list = GetValue<ObservableCollection<User>>(GroupPermissionsProperty);

                if(list == null)
                    list = new ObservableCollection<User>(ServiceLocator.Default.ResolveType<Logic.Security.IUserService>().GetByGroupId(Id));

                return list;
            }
            set { SetValue(UsersProperty, value); }
        }

        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));

        #endregion

        #region Methods

        public override void SaveModel()
        {
            SaveModel<Group>();
        }

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}