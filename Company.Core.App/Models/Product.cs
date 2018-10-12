using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Company.Core.App.Services.Loading;

namespace Company.Core.App.Models
{
    public class Product : ModelBase
    {
        private readonly CustomerLoadingService cusomterLoadingService = new CustomerLoadingService();

        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int));


        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        public Customer Owner
        {
            get { return GetValue<Customer>(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        public static readonly PropertyData OwnerProperty = RegisterProperty(nameof(Owner), typeof(Customer));

        public void OpenCustomer(int id)
        {
            // TODO : Bei dem Aufruf sollte Products direkt mitgeliefert werden.
            Main.Instance.ActivContent = cusomterLoadingService.GetById(id);
        }

        public void Save()
        {
            // TODO : Serialisation in die DB
            throw new NotImplementedException();
        }
    }
}
