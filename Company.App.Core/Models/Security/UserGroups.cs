using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.App.Core.Models.Security
{
    [Table("UserGroups")]
    public class UserGroups : ModelBase2
    {
        public UserGroups() : base(true)
        { }

        public UserGroups(bool isNew) : base(isNew)
        { }

        public override int Id { get; protected set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int GroupId { get; set; }
        public Group Group { get; set; }


        public override void SaveModel()
        {
            SaveModel<UserGroups>();
        }
    }
}
