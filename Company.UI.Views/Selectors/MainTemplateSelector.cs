using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Company.Core.ViewModels;

namespace Company.UI.Views.Selectors
{
    public class MainTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HomeDataTemplate { get; set; }
        public DataTemplate CustomerDataTemplate { get; set; }
        public DataTemplate ProductDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item != null)
            {
                if(item is Company.Core.App.Models.Home)
                    return HomeDataTemplate;
                if(item is Company.Core.App.Models.Customer)
                    return CustomerDataTemplate;
                if(item is Company.Core.App.Models.Product)
                    return ProductDataTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
