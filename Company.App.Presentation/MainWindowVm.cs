﻿using System;
using Catel.Data;
using Catel.MVVM;
using Company.App.Core.Models.App;

namespace Company.App.Presentation
{
    public class MainWindowVm : ViewModelBase
    {
        public MainWindowVm()
        {
            Model = Main.Instance;
        }


        [Model]
        public Main Model
        {
            get { return GetValue<Main>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Main));


        [ViewModelToModel]
        public new string Title
        {
            get { return GetValue<string>(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly PropertyData TitleProperty = RegisterProperty(nameof(Title), typeof(string));


        [ViewModelToModel]
        public ModelBase ActivContent
        {
            get
            {
                ModelBase modelBase = GetValue<ModelBase>(ActivContentProperty);
                if(modelBase is Company.App.Core.Models.App.Home)
                    return modelBase as Company.App.Core.Models.App.Home;
                if(modelBase is Company.App.Core.Models.Basic.Home)
                    return modelBase as Company.App.Core.Models.Basic.Home;
                if(modelBase is Company.App.Core.Models.Security.Home)
                    return modelBase as Company.App.Core.Models.Security.Home;

                return null;
            }
            set { SetValue(ActivContentProperty, value as ModelBase); }
        }

        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase));

        public Command OpenMainModulCommand { get; private set; }
        public Command OpeBasicModulCommand { get; private set; }
        public Command OpenSecurityModulCommand { get; private set; }
    }
}
