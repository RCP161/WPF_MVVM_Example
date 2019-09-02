using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Models
{
    public interface IEditable
    {
        public int Id { get; }

        public void MarkAsDeleted();

        public void AfterLoad();

        public void SaveModel();
    }
}
