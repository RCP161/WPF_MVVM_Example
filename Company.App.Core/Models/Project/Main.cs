using System;
using System.Collections.Generic;
using System.Text;
using Catel.Data;

namespace Company.App.Core.Models.Project
{
    public class Main : ModelBase1
    {
        private Main()
        {
            Title = "WPF .Net Core 3 App 1.0.0";
            ActivContent = new Home();
        }

        private static Main _instance;
        public static Main Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Main();

                return _instance;
            }
        }

        #region Properties

        public string Title
        {
            get { return GetValue<string>(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly PropertyData TitleProperty = RegisterProperty(nameof(Title), typeof(string));


        public ModelBase1 ActivContent
        {
            get { return GetValue<ModelBase1>(ActivContentProperty); }
            set { SetValue(ActivContentProperty, value); }
        }

        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase1));

        #endregion
    }
}
