using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Company.Core.App.Common;

namespace Company.Core.App.Models
{
    public abstract class ModelBase2 : ModelBase1
    {
        // Model für alle speicherbaren Objekte

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public abstract int Id { get; set; }


        [NotMapped]
        [IgnoreOnStateAttribute]
        public Enums.StateEnum State
        {
            get { return GetValue<Enums.StateEnum>(StateProperty); }
            private set { SetValue(StateProperty, value); }
        }
        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(Enums.StateEnum));
    }
}
