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
            

            ServiceLocator.Default.RegisterType<Company.Core.App.Data.DataBase.Interfaces.IDbConfigruation, Config>();
            ServiceLocator.Default.RegisterType<Company.Core.App.Data.DataBase.Interfaces.IDataAccess, Company.Core.App.Data.DataBase.EfContext>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Core.App.Data.Interfaces.IUnitOfWork, Company.Core.App.Data.DataBase.UnitOfWork>(RegistrationType.Transient);

            IViewModelLocator viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();
            viewModelLocator.Register(typeof(Company.UI.Views.Main), typeof(Company.Core.ViewModels.MainVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Home), typeof(Company.Core.ViewModels.HomeVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Customer), typeof(Company.Core.ViewModels.CustomerVm));
            viewModelLocator.Register(typeof(Company.UI.Views.CustomerItem), typeof(Company.Core.ViewModels.CustomerItemVm));
            viewModelLocator.Register(typeof(Company.UI.Views.CustomerSearchTextBox), typeof(Company.Core.ViewModels.CustomerSearchTextBoxVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Product), typeof(Company.Core.ViewModels.ProductVm));
            viewModelLocator.Register(typeof(Company.UI.Views.ProductItem), typeof(Company.Core.ViewModels.ProductItemVm));

            base.OnStartup(e);



            // TODO :    === Themen die noch anstehen ===
            // - Validation 
            // - Ef concurrency ? Oder Locktabelle? -> concurrency könnte fehlerhafte programmierung aufdecken. (siehe nächste Zeile)
            // - ReadOnlyVms und ReadOnly Properties an VMs prüfen
            // - EF generische Methode wieder zum laufen bringen
            // - Erben von SavableModelBase?


            // - Eine Art Instanz refresher? 2 Instanzen des selben Datensatzes refreshen,
            //   oder den bereits geladenen Datensatz qualifizieren und einen verweis auf ihn verwenden (Prio3)
            // - Mehrsprachenfähigkeit (Prio3)
            // - ReadOnly bei keinem Schreibrecht (Prio3)

            // Locator (service, ViewModel, ...) über Namesnkonvention regeln

            // Fähigkeiten von Catel noch prüfen, was geht noch so
            // Fähigkeiten von Catel.Fody prüfen
            // Fähigkeiten von AutoMapper prüfen
            // EF Plus prüfen

            // CodeGeneration (Custom Attribute für Properties im Model und ViewModel

            // Warum benötigen der Test und Project das EF? Das sollte doch gekapselt sein ...
            // UI.Views benötigt den Verweis auf Core.App wegen TemplateSelectors und weil Catel an das Model bindet
            // PRoject hat derzeit das AutoMapper Nuget. Das muss nicht sein, ist aber bis jetzt hier Zentral verwaltet

            // nameof oder Reflection bei den Include Querries an den Repros verwenden?
            // Benötigt Qerry noch sowas wie "Expression<Func<TEntity, bool>> predicate" an den Interfaces?
        }
    }
}
