using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.IoC;
using Company.Core.App.Services.Data;
using Company.Core.App.Services.Data.Interfaces;

namespace Company.Core.App.Models
{
    [Table("Product")]
    public class Product : ModelBase2
    {
        private readonly ICustomerDataService customerDataService;
        private readonly IProductDataService productDataService;

        public Product() : this(false)
        { }

        public Product(bool isNew)
        {
            customerDataService = ServiceLocator.Default.ResolveType<ICustomerDataService>();
            productDataService = ServiceLocator.Default.ResolveType<IProductDataService>();

            if(isNew)
                State = Common.StateEnum.Created;
        }


        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int));


        [Required, MaxLength(100)]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [Required]
        public Customer Owner
        {
            get { return GetValue<Customer>(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        public static readonly PropertyData OwnerProperty = RegisterProperty(nameof(Owner), typeof(Customer));


        protected override string GetDisplayText()
        {
            return Name;
        }

        public void OpenCustomer(int id)
        {
            Main.Instance.ActivContent = (Customer)customerDataService.GetCompleteById(id);
        }

        public override void Save()
        {
            productDataService.SaveOrUpdate(this);
        }

        public void OpenHome()
        {
            Main.Instance.ActivContent = new Home();
        }
    }
}
