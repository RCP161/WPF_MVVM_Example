using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.IoC;

namespace Company.App.Core.Models.Basic
{
    public class Home : ModelBase1
    {
        public Home()
        {
            Persons  = new ObservableCollection<Person>(ServiceLocator.Default.ResolveType<Logic.Basic.IPersonService>().LoadPersons());
        }

        #region Properties

        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Persons), typeof(ObservableCollection<Person>));

        #endregion

        #region Methods

        public void OpenPerson(Person selectedPerson)
        {
            // Rechte, etc.
            ServiceLocator.Default.ResolveType<Logic.Project.IMainUiService>().SetMainContent(selectedPerson);
        }

        #endregion

    }
}
