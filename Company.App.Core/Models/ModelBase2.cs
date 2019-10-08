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

        public void MarkAsUnchanged()
        {
            State = StateEnum.Unchanged;
        }

        protected override sealed string GetDisplyTextWithState()
        {
            string dpText = GetDisplayText();

            if(State.HasFlag(StateEnum.Modified) || State.HasFlag(StateEnum.Created))
                dpText += "*";

            return dpText;
        }
    }
}
