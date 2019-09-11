using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.App.Core.Logic.App;
using Company.App.Core.Models;

namespace Company.App.Core.Models.Security
{
    [Table("Group")]
    public class Group : ModelBase2<Group>
    {
        public Group() : base(false)
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
            get { return GetValue<ObservableCollection<GroupPermission>>(GroupPermissionsProperty); }
            set { SetValue(GroupPermissionsProperty, value); }
        }

        public static readonly PropertyData GroupPermissionsProperty = RegisterProperty(nameof(GroupPermissions), typeof(ObservableCollection<GroupPermission>));



        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(GroupPermissionsProperty); }
            set { SetValue(UsersProperty, value); }
        }

        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));


        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}