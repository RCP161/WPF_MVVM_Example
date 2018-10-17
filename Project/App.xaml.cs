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
            

            ServiceLocator.Default.RegisterType<Company.Core.App.IDbConfigruation, Config>();
            ServiceLocator.Default.RegisterType<Company.Core.App.IDataAccess, Company.Core.App.EfContext>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Core.App.Querries.IUnitOfWork, Company.Core.App.Querries.UnitOfWork>(RegistrationType.Transient);

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
            // - Interface pro Objekt
            // - Basisiklasse für Dirty etc (https://catelproject.atlassian.net/wiki/spaces/CTL/pages/2359400/Using+ModelBase+as+base+for+entities)
            // - Save und Cancel über IEdit abbilden
            // - Das hinzufügen neuer Elemente
            // - Validation 
            // - Beim Speichern weiß ich nicht, ob er virtuals ignoriert werden. Diese sollten ja dennoch gespeichert werden.
            //   In Listen sollten sich Objekte selbst speichern. -> Andere MappingConfig fürs speichern benötigt?
            //   Wahrscheinlich nicht, da man das Mapping wahrscheinlich auch in beide Seiten angeben muss und dort dann die Destination Extension verwenden kann
            // - Wird aber wohl eh 2 Mapings benötigt. Eines mit ignore Virtuals und eines ohne
            // - Ef concurrency ? Oder Locktabelle? -> concurrency könnte fehlerhafte programmierung aufdecken. (siehe nächste Zeile)
            // - private Setter in den ReadOnlyVms entfernen und Readonly setzen?

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

            // ACHTUNG: Derzeit mit LazyLoading, damit wird der RAM zulaufen, weil alles nach geladen werden würde, aber nichts wieder entfernt.
            // Doch verschiedene Instanzen? Siehe oben InstanzRefresher

            // Abgelehnt:
            // AutoMapper in Repositories verweschieben?
            // => würde einen verweis von einer unteren Schicht auf eine höhere bedeuten. Wäre machbar, sieht aber unschön aus
        }
    }
}
