﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.App.Core.Logic.App;
using Company.App.Core.Models;

namespace Company.App.Core.Models.Security
{
    [Table("Permission")]
    public class Permission : ModelBase2<Permission>
    {
        public Permission() : base(false)
        { }

        public Permission(bool isNew) : base(isNew)
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


        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string));


        protected override ISaveableService<Permission> SaveableService { get { return ServiceLocator.Default.ResolveType<Logic.Security.IPermissionService>(); } }


        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}
