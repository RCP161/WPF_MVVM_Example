using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Company.Core.App.Services.Loading;

namespace Company.Core.App.Models
{
    [Table("Product")]
    public class Product : ModelBase, IEntity
    {
        private readonly CustomerLoadingService cusomterLoadingService = new CustomerLoadingService();
        private readonly ProductLoadingService productLoadingService = new ProductLoadingService();

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
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

        public void OpenCustomer(int id)
        {
            Main.Instance.ActivContent = cusomterLoadingService.GetCompleteById(id);
        }

        public void Save()
        {
            productLoadingService.Save(this);
        }
    }
}
