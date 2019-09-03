using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Common;

namespace Company.App.Core.Models
{
    public interface IEditable
    {
        public int Id { get; }

        public StateEnum State { get; }

        public void MarkAsDeleted();

        public void AfterLoad();

        public void SaveModel();
    }
}
