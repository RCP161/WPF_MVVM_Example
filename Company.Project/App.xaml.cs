using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Catel.IoC;
using Catel.MVVM;

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
            //            LogManager.AddDebugListener();
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



            // =========================
            //          UI  
            // =========================
            IViewModelLocator viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();

            // Project
            viewModelLocator.Register(typeof(Company.Project.UI.MainWindow), typeof(Company.Project.Presentation.MainWindowVm));
            viewModelLocator.Register(typeof(Company.Project.UI.Home), typeof(Company.Project.Presentation.HomeVm));

            // Basic
            viewModelLocator.Register(typeof(Company.Basic.UI.Home), typeof(Company.Basic.Presentation.HomeVm));

            // Security
            viewModelLocator.Register(typeof(Company.Security.UI.Home), typeof(Company.Security.Presentation.HomeVm));


#if DEBUG
            new TestData();
#endif

            Current.MainWindow = new Company.Project.UI.MainWindow();
            Current.MainWindow.Show();

            base.OnStartup(e);

            // TODO : List

            // Speichern eines Eltern elements, dessen Kind gelöscht wurde (bzw, als gelöscht markiert)

            // Weitere Themen
            // nameof oder Reflection bei den Include Querries an den Repros verwenden? Probleme beim Auteilen von klassen 
            // Benötigt Qerry noch sowas wie "Expression<Func<TEntity, bool>> predicate" an den Interfaces?
            // DeleteCascade ist im EF immer an. Austellen ist derzeit nicht möglich. Sollte man aber noch mit größerer Modelanzahl testen
            // Klassen halten eine ClassInfo, die die Relection Informationen enthält. Somit könnte man alle Listen etc ausfindig machen zum speichern, CompleteLoad, Validierung, ...

            // Optimierungen
            // - Ef:                    Concurrency? (könnte fehlerhafte programmierung/refreshing aufdecken)
            // - DataServices:          AfterLoad sollte alle KindObjekte auch Clearen
            // - Model:                 Ableiten von SavableModelBase für Serialisation?
            // - ViewModelBase:         Ableiten und Save in ModelBase2 voraussetzen? Dann könnte man auch das SaveAsync, DisplayText direkt mit einbinden
            // - ReadOnlyVms:           ReadOnly Properties an VMs prüfen
            // - Namesnkonvention:      Locator (service, ViewModel, ...) über Namesnkonvention regeln
            // - UserControl:           UnloadBehavior="CloseViewModel" als Standard

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