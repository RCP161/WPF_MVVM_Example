using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Company.App.UI.Selectors
{
    public class MainContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AppHomeDataTemplate { get; set; }
        public DataTemplate BasicHomeDataTemplate { get; set; }
        public DataTemplate SecurityHomeDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item != null)
            {
                if(item is Company.App.Core.Models.App.Home)
                    return AppHomeDataTemplate;
                if(item is Company.App.Core.Models.App.Home)
                    return BasicHomeDataTemplate;
                if(item is Company.App.Core.Models.App.Home)
                    return SecurityHomeDataTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
