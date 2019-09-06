using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.App.Core.Logic;
using Company.App.Core.Models;
using Company.App.Core.Models.Security;

namespace Company.App.Core.Models.Basic
{
    [Table("Person")]
    public class Person : ModelBase2
    {
        public Person() : this(true)
        { }

        public Person(bool isNew) : base(isNew)
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


        [MaxLength(255)]
        public string Surename
        {
            get { return GetValue<string>(SurenameProperty); }
            set { SetValue(SurenameProperty, value); }
        }
        public static readonly PropertyData SurenameProperty = RegisterProperty(nameof(Surename), typeof(string));


        public virtual User User
        {
            get { return GetValue<User>(UserProperty); }
            set { SetValue(UserProperty, value); }
        }
        public static readonly PropertyData UserProperty = RegisterProperty(nameof(User), typeof(User), null);

        #endregion

        #region Methods

        public override void SaveModel()
        {
            SaveModel<Person>();
        }

        protected override string GetDisplayText()
        {
            return String.Format("{0}, {1}", Surename, Name);
        }

        #endregion

    }
}
