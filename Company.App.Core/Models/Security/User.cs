using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;

namespace Company.Project.Core.Models.Security
{
    [Table("User")]
    public class User : ModelBase2
    {
        public User(bool isNew) : base(isNew)
        { }

        #region Properties

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
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


        public virtual ICollection<Group> Groups { get; set; }

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return LogIn;
        }

        #endregion
    }
}