using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Company.App.Core.Models;

namespace Company.App.Core.Models.Security
{
    [Table("Permission")]
    public class Permission : ModelBase2
    {
        public Permission() : base(true)
        { }

        public Permission(bool isNew) : base(isNew)
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


        [Required]
        public bool Read
        {
            get { return GetValue<bool>(ReadProperty); }
            set { SetValue(ReadProperty, value); }
        }
        public static readonly PropertyData ReadProperty = RegisterProperty(nameof(Read), typeof(bool));


        [Required]
        public bool Write
        {
            get { return GetValue<bool>(WriteProperty); }
            set { SetValue(WriteProperty, value); }
        }
        public static readonly PropertyData WriteProperty = RegisterProperty(nameof(Write), typeof(bool));


        public virtual ICollection<Group> Groups { get; set; }

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}
