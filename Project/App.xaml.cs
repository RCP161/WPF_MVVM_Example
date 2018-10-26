using System.Windows;
using Catel.IoC;
using Catel.Logging;
using Catel.MVVM;

namespace Project
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //#if DEBUG
            //            LogManager.AddDebugListener();
            //#endif
            

            ServiceLocator.Default.RegisterType<Company.Core.App.Data.DataBase.Interfaces.IDbConfigruation, Config>(RegistrationType.Singleton);
            ServiceLocator.Default.RegisterType<Company.Core.App.Data.DataBase.Interfaces.IDataAccess, Company.Core.App.Data.DataBase.EfContext>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Core.App.Data.Interfaces.IUnitOfWork, Company.Core.App.Data.DataBase.UnitOfWork>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Core.App.Services.Data.Interfaces.ICustomerDataService, Company.Core.App.Services.Data.CustomerDataService>(RegistrationType.Singleton);
            ServiceLocator.Default.RegisterType<Company.Core.App.Services.Data.Interfaces.IProductDataService, Company.Core.App.Services.Data.ProductDataService>(RegistrationType.Singleton);
            ServiceLocator.Default.RegisterType<Company.Core.App.Common.IMessageBoxService, Company.UI.Views.Services.MessageBoxService>(RegistrationType.Transient);
            


            IViewModelLocator viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();
            viewModelLocator.Register(typeof(Company.UI.Views.Main), typeof(Company.Core.ViewModels.MainVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Home), typeof(Company.Core.ViewModels.HomeVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Customer), typeof(Company.Core.ViewModels.CustomerVm));
            viewModelLocator.Register(typeof(Company.UI.Views.CustomerItem), typeof(Company.Core.ViewModels.CustomerItemVm));
            viewModelLocator.Register(typeof(Company.UI.Views.CustomerSearchTextBox), typeof(Company.Core.ViewModels.CustomerSearchTextBoxVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Product), typeof(Company.Core.ViewModels.ProductVm));
            viewModelLocator.Register(typeof(Company.UI.Views.ProductItem), typeof(Company.Core.ViewModels.ProductItemVm));

            base.OnStartup(e);

            // TODO :           === Themen Besprechung ===

            // Weitere Schritte
            // - Delete löscht gerade auch Kinder
            // - Klassen halten eine ClassInfo, die die Relection Informationen enthält. Somit könnte man alle Listen etc ausfindig machen zum speichern, CompleteLoad, Validierung, ...
            // - EF heraus lösen und selbst aufsetzen? Dann noch IsDirty und IsReadOnly ignorieren, dann wieder Generische Methode

            // Korrekturen
            // - EF:                    Generische Methode wieder zum laufen bringen

            // Fragen
            // nameof oder Reflection bei den Include Querries an den Repros verwenden? Probleme beim Auteilen von klassen 
            // Benötigt Qerry noch sowas wie "Expression<Func<TEntity, bool>> predicate" an den Interfaces?
            // Zweifach Revert / Save

            // Optimierungen
            // - Ef:                    Concurrency? (könnte fehlerhafte programmierung/refreshing aufdecken)
            // - DataServices:          AfterLoad sollte alle KindObjekte auch Clearen
            // - Model:                 Ableiten von SavableModelBase für Serialisation?
            // - ViewModelBase:         Ableiten und Save in ModelBase2 voraussetzen? Dann könnte man auch das SaveAsync, DisplayText direkt mit einbinden
            // - ReadOnlyVms:           ReadOnly Properties an VMs prüfen
            // - Namesnkonvention:      Locator (service, ViewModel, ...) über Namesnkonvention regeln

            // Mögliche Erweiterungen
            // - Instanz refresher:     2 Instanzen des selben Datensatzes refreshen 
            // - Validation
            // - Serialisation
            // - Mehrsprachenfähigkeit
            // - Schreibrechte
            // - EF Plus prüfen
            // - CodeGeneration
            // - Weitere Nugets von Orc http://opensource.wildgums.com/orc.entityframework/
            // - Catel Fody:            Vereinfacht die schreibweise der Properties. Muss aber auch erst konfiguriert werden
        }
    }
}
