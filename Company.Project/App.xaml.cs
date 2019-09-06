using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;

namespace Company.Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
//#if DEBUG
//            Catel.Logging.LogManager.AddDebugListener();
//#endif


            // =========================
            //      App  
            // =========================
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Common.IDbConfigruation, Config>(RegistrationType.Singleton);
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Common.IDataAccess, Company.App.DataSource.Common.EfContext>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Common.IUnitOfWork, Company.App.DataSource.Common.UnitOfWork>(RegistrationType.Transient);


            // =========================
            //        Services  
            // =========================

            // App
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.App.ISaveableService, Company.App.Logic.SaveableService>(RegistrationType.Transient);

            // Project
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Project.IMainUiService, Company.Project.Logic.MainUiService>(RegistrationType.Transient);

            // Basic
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Basic.IPersonService, Company.Basic.Logic.PersonService>(RegistrationType.Transient);

            // Security
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Security.IUserService, Company.Security.Logic.UserService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Security.IGroupService, Company.Security.Logic.GroupService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Security.IPermissionService, Company.Security.Logic.PermissionService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Security.IGroupPermissionService, Company.Security.Logic.GroupPermissionService>(RegistrationType.Transient);



            // =========================
            //          UI  
            // =========================
            IViewModelLocator viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();

            // Project
            viewModelLocator.Register(typeof(Company.Project.UI.MainWindow), typeof(Company.Project.Presentation.MainVm));
            viewModelLocator.Register(typeof(Company.Project.UI.HomeView), typeof(Company.Project.Presentation.HomeVm));

            // Basic
            viewModelLocator.Register(typeof(Company.Basic.UI.HomeView), typeof(Company.Basic.Presentation.HomeVm));
            viewModelLocator.Register(typeof(Company.Basic.UI.PersonView), typeof(Company.Basic.Presentation.PersonVm));

            // Security
            viewModelLocator.Register(typeof(Company.Security.UI.HomeView), typeof(Company.Security.Presentation.HomeVm));
            viewModelLocator.Register(typeof(Company.Security.UI.GroupView), typeof(Company.Security.Presentation.GroupVm));
            viewModelLocator.Register(typeof(Company.Security.UI.UserView), typeof(Company.Security.Presentation.UserVm));


            // =========================
            //        Windows  
            // =========================
            IUIVisualizerService uIVisualizerService = ServiceLocator.Default.ResolveType<IUIVisualizerService>();

            uIVisualizerService.Register(typeof(Company.Project.Presentation.MainVm), typeof(Company.Project.UI.MainWindow));


#if DEBUG
            new TestData();
#endif


            base.OnStartup(e);

            uIVisualizerService.ShowAsync<Company.Project.Presentation.MainVm>();

            // TODO : List

            // Weitere Themen
            // DeleteCascade ist im EF immer an. Austellen ist derzeit nicht möglich. Sollte man aber noch mit größerer Modelanzahl testen
            // Klassen halten eine ClassInfo, die die Relection Informationen enthält, für Validierung, ...
            // Auf Close Methode von Model/Vm hören und Dirty(State) überprüfen

            // Optimierungen
            // - Ef:                    Concurrency? (könnte fehlerhafte programmierung/refreshing aufdecken)
            // - DataServices:          AfterLoad sollte alle KindObjekte auch Clearen
            // - Model:                 Ableiten von SavableModelBase für Serialisation?
            // - ReadOnlyVms:           ReadOnly Properties an VMs prüfen
            // - Namesnkonvention:      Locator (service, ViewModel, ...) über Namesnkonvention regeln

            // Mögliche Erweiterungen
            // - Instanz refresher:     2 Instanzen des selben Datensatzes refreshen, nach Speichern
            // - Validation
            // - Serialisation
            // - Mehrsprachenfähigkeit
            // - Schreibrechte
            // - EF Plus prüfen
            // - Weitere Nugets von Orc http://opensource.wildgums.com/orc.entityframework/
            // - CodeGeneration
            //   - EF DB Set (würde die funktion überflüssig machen)
            //   - Respository
            //   - Service (Logic)
            //   - VM
            //   - View
            //   - ContentTemplates eintrag
        }
    }
}