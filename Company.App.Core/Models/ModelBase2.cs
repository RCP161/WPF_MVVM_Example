using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.IoC;
using Company.App.Core.Common;

namespace Company.App.Core.Models
{
    // Model für alle speicherbaren Objekte

    public abstract class ModelBase2 : ModelBase1, IEditable
    {
        public ModelBase2(bool isNew)
        {
            if(isNew)
                State = Common.StateEnum.Created;
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public abstract int Id { get; protected set; }


        public void MarkAsDeleted()
        {
            State = StateEnum.Deleted;
        }

        public void AfterLoad()
        {
            State = StateEnum.Unchanged;
        }

        public void SaveModel()
        {
            // TODO : Hier gehts weiter
            // 1. Brauche Hier den Typ. DBSet<ModelBase2> kennt er nicht
            // 2. UnitOfWork von Catel?

            Logic.App.ISaveableService service = ServiceLocator.Default.ResolveType<Logic.App.ISaveableService>();
            service.Save(this);
        }
    }
}
