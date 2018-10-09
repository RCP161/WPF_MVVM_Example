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

            AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company.Data.Enities.Customer, Company.Core.App.Models.Customer>();
                cfg.CreateMap<Company.Data.Enities.Product, Company.Core.App.Models.Product>();
            });

            AutoMapper.Mapper mapper = new AutoMapper.Mapper(config);


            ServiceLocator.Default.RegisterType<Company.DataAccess.If.IDbConfigruation, Config>();
            ServiceLocator.Default.RegisterType<Company.DataAccess.If.IDataAccess, Company.DataAccess.Ef.EfContext>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.DataQueries.If.IUnitOfWork, Company.DataQueries.Repositories.UnitOfWork>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterInstance<AutoMapper.IMapper>(mapper);

            IViewModelLocator viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();
            viewModelLocator.Register(typeof(Company.UI.Views.Main), typeof(Company.Core.ViewModels.MainVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Home), typeof(Company.Core.ViewModels.HomeVm));
            viewModelLocator.Register(typeof(Company.UI.Views.Customer), typeof(Company.Core.ViewModels.CustomerVm));
            viewModelLocator.Register(typeof(Company.UI.Views.CustomerItem), typeof(Company.Core.ViewModels.CustomerItemVm));

            base.OnStartup(e);

            // TODO : Themen die noch anstehen
            // Save und Cancel über IEdit abbilden (macht glaube ich auch Catel schon)
            // Das hinzufügen neuer Elemente
            // Mehrsprachenfähigkeit
            // ReadOnly bei keinem Schreibrecht

            // Locator (service, ViewModel, ...) über Namesnkonvention regeln

            // Fähigkeiten von Catel noch prüfen, was geht noch so
            // Fähigkeiten von Catel.Fody prüfen
            // Fähigkeiten von AutoMapper prüfen

            // CodeGeneration (Custom Attribute für Properties im Model und ViewModel

            // Warum benötigen der Test und Project das EF? Das sollte doch gekapselt sein ...
            // UI.Views benötigt den Verweis auf Core.App wegen TemplateSelectors und weil Catel an das Model bindet
            // PRoject hat derzeit das AutoMapper Nuget. Das muss nicht sein, ist aber bis jetzt hier Zentral verwaltet

            // AutoMapper in Repositories verweschieben?
        }
    }
}
