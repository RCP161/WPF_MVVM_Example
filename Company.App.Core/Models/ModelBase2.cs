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

        public abstract void SaveModel();

        protected void SaveModel<T>() where T : ModelBase2
        {
            Logic.App.ISaveableService service = ServiceLocator.Default.ResolveType<Logic.App.ISaveableService>();
            service.Save((T)this);

            if(State == StateEnum.Modified || State == StateEnum.Created)
                State = StateEnum.Unchanged;
        }
    }
}
