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

    public abstract class ModelBase2<T> : ModelBase1, IEditable where T : ModelBase2<T>
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

        public void Save()
        {
            Save(null);
        }

        public void Save(IDataAccess dataAccess)
        {
            SaveableService.Save((T)this, dataAccess);

            if(State == StateEnum.Modified || State == StateEnum.Created)
                State = StateEnum.Unchanged;
        }
    }
}
