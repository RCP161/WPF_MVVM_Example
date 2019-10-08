using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.App.Core.Models.Basic;

namespace Company.App.Core.Models.Security
{
    [Table("User")]
    public class User : ModelBase2
    {
        public User() : base(true)
        { }

        public User(bool isNew) : base(isNew)
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
        public string LogIn
        {
            get { return GetValue<string>(LogInProperty); }
            set { SetValue(LogInProperty, value); }
        }
        public static readonly PropertyData LogInProperty = RegisterProperty(nameof(LogIn), typeof(string));


        [Required, MaxLength(255)]
        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly PropertyData PasswordProperty = RegisterProperty(nameof(Password), typeof(string));


        public Person Person
        {
            get { return GetValue<Person>(PersonProperty); }
            set { SetValue(PersonProperty, value); }
        }
        public static readonly PropertyData PersonProperty = RegisterProperty(nameof(Person), typeof(Person), null);


        public ObservableCollection<Group> Groups
        {
            get
            {
                ObservableCollection<Group> list = GetValue<ObservableCollection<Group>>(GroupsProperty);

                if(list == null)
                    list = new ObservableCollection<Group>(ServiceLocator.Default.ResolveType<Logic.Security.IGroupService>().GetByUserId(Id));

                return list;
            }
            set { SetValue(GroupsProperty, value); }
        }
        public static readonly PropertyData GroupsProperty = RegisterProperty(nameof(Groups), typeof(ObservableCollection<Group>));

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return LogIn;
        }

        #endregion
    }
}