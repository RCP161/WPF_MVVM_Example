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
#if DEBUG
            LogManager.AddDebugListener();
#endif
            ServiceLocator.Default.RegisterType<Company.DataAccess.If.IDbConfigruation, Config>();
            ServiceLocator.Default.RegisterType<Company.DataAccess.If.IDataAccess, Company.DataAccess.Ef.EfContext>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.DataQueries.If.IUnitOfWork, Company.DataQueries.Repositories.UnitOfWork>(RegistrationType.Transient);

            // TODO : Über Namesnkonvention regeln
            IViewModelLocator viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();
            viewModelLocator.Register(typeof(Company.UI.Views.Main), typeof(Company.Core.ViewModels.MainVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Home), typeof(Company.Core.ViewModels.HomeVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Customer), typeof(Company.Core.ViewModels.CustomerVm));

            base.OnStartup(e);

            // TODO : Themen die jetzt nicht beachtet wurden
            // Save und Cancel über IEdit abbilden (macht glaube ich auch Catel schon)
            // Mehrsprachenfähigkeit
            // ReadOnly bei keinem Schreibrecht
            // Das hinzufügen neuer Elemente
        }
    }
}
