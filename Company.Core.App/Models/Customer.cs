using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [Table("Customer")]
    public class Customer : ModelBase2
    {
        private readonly IProductDataService productDataService;
        private readonly ICustomerDataService customerDataService;

        public Customer() : this(false)
        { }

        public Customer(bool isNew)
        {
            customerDataService = ServiceLocator.Default.ResolveType<ICustomerDataService>();
            productDataService = ServiceLocator.Default.ResolveType<IProductDataService>();

            if(isNew)
                State = Common.StateEnum.Created;
        }

        #region Properties

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


        [MaxLength(100)]
        public string CustomerNumber
        {
            get { return GetValue<string>(CustomerNumberProperty); }
            set { SetValue(CustomerNumberProperty, value); }
        }
        public static readonly PropertyData CustomerNumberProperty = RegisterProperty(nameof(CustomerNumber), typeof(string));


        public ObservableCollection<Product> Products
        {
            get { return GetValue<ObservableCollection<Product>>(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }
        public static readonly PropertyData ProductProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>));

        #endregion

        #region Methods
        
        protected override string GetDisplayText()
        {
            return String.Format("{0} / {1}", CustomerNumber, Name);
        }

        public void OpenProduct(int id)
        {
            Main.Instance.ActivContent = productDataService.GetById(id);
        }

        public void CreateProduct()
        {
            Product product = new Product(true);
            product.Owner = this;
            Main.Instance.ActivContent = product;
        }

        public void OpenCustomer(int id)
        {
            Main.Instance.ActivContent = customerDataService.GetCompleteById(id);
        }

        public override void Save()
        {
            customerDataService.SaveOrUpdate(this);
        }

        public void OpenHome()
        {
            Main.Instance.ActivContent = new Home();
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            product.MarkAsDeleted();
        }

        #endregion
    }
}
