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

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item != null)
            {
                if(item is Core.Models.Home)
                    return HomeDataTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
