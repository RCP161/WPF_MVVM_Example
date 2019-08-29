using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.App.Core.Models.Basic;

namespace Company.Basic.Presentation
{
    public class HomeVm : ViewModelBase
    {
        public HomeVm(Home home)
        {
            Model = home;
            OpenPersonCommand = new Command(() => Model.OpenPerson(SelectedPerson));
        }

        #region Properties

        [Model]
        public Home Model
        {
            get { return GetValue<Home>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Home));


        [ViewModelToModel]
        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Persons), typeof(ObservableCollection<Person>));


        public Person SelectedPerson
        {
            get { return GetValue<Person>(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }
        public static readonly PropertyData SelectedPersonProperty = RegisterProperty(nameof(SelectedPerson), typeof(Person));


        public Command OpenPersonCommand { get; private set; }

        #endregion
    }
}
