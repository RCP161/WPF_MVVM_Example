using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Company.App.Core.Common;

namespace Company.App.Core.Models
{
    public abstract class ModelBase2 : ModelBase1
    {
        // Model für alle speicherbaren Objekte

        public ModelBase2(bool isNew)
        {
            if(isNew)
                State = Common.StateEnum.Created;
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public abstract int Id { get; set; }

        public void MarkAsDeleted()
        {
            State = StateEnum.Deleted;
        }
    }
}
