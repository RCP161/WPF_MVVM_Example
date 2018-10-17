using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Company.Core.App.Services.Loading;

namespace Company.Core.App.Models
{
    [Table("Customer")]
    public class Customer : ModelBase, IEntity
    {
        private readonly ProductLoadingService productLoadingService = new ProductLoadingService();
        private readonly CustomerLoadingService cusomterLoadingService = new CustomerLoadingService();

        #region Properties

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
            set
            {
                SetValue(NameProperty, value);
                SetDisplayText();
            }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [MaxLength(100)]
        public string CustomerNumber
        {
            get { return GetValue<string>(CustomerNumberProperty); }
            set
            {
                SetValue(CustomerNumberProperty, value);
                SetDisplayText();
            }
        }
        public static readonly PropertyData CustomerNumberProperty = RegisterProperty(nameof(CustomerNumber), typeof(string));

        [NotMapped]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            private set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

        public ObservableCollection<Product> Products
        {
            get { return GetValue<ObservableCollection<Product>>(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }
        public static readonly PropertyData ProductProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>));

        #endregion

        #region Methods

        private void SetDisplayText()
        {
            string dpText = String.Format("{0} / {1}", CustomerNumber, Name);

            // TODO : [Prio2] Verhalten in Basisklasse auslagern
            if(IsDirty)
                dpText += "*";

            DisplayText = dpText;
        }

        public void OpenProduct(int id)
        {
            Main.Instance.ActivContent = productLoadingService.GetById(id);
        }

        public void CreateProduct()
        {
            Product product = new Product();
            product.Owner = this;
            Main.Instance.ActivContent = product;
        }

        public void OpenCustomer(int id)
        {
            Main.Instance.ActivContent = cusomterLoadingService.GetById(id);
        }

        public void Save()
        {
            cusomterLoadingService.Save(this);
        }

        #endregion
    }
}
