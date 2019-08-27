using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Company.App.Core.Models;

namespace Company.App.Core.Models.Security
{
    [Table("Group")]
    public class Group : ModelBase2
    {
        public Group(bool isNew) : base(isNew)
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
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}