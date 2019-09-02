﻿using System;
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
            //      Repositories  
            // =========================
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Common.IDbConfigruation, Config>(RegistrationType.Singleton);
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Common.IDataAccess, Company.App.DataSource.Common.EfContext>(RegistrationType.Singleton);
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Repositories.IUnitOfWork, Company.App.DataSource.Repositories.UnitOfWork>(RegistrationType.Transient);

            // App
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Repositories.App.IModelBase2Repository, Company.App.DataSource.Repositories.App.ModelBase2Repository>(RegistrationType.Singleton);

            // Project

            // Basic
            ServiceLocator.Default.RegisterType<Company.App.DataSourceDefinition.Repositories.Basic.IPersonRepository, Company.App.DataSource.Repositories.Basic.PersonRepository>(RegistrationType.Singleton);

            // Security


            // =========================
            //        Services  
            // =========================

            // App
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.App.ISaveableService, Company.App.Logic.SaveableService>(RegistrationType.Singleton);

            // Project
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Project.IMainUiService, Company.Project.Logic.MainUiService>(RegistrationType.Singleton);

            // Basic
            ServiceLocator.Default.RegisterType<Company.App.Core.Logic.Basic.IPersonService, Company.Basic.Logic.PersonService>(RegistrationType.Transient);

            // Security

            //ServiceLocator.Default.RegisterType<Company.Core.App.Services.Data.Interfaces.ICustomerDataService, Company.Core.App.Services.Data.CustomerDataService>(RegistrationType.Singleton);
            //ServiceLocator.Default.RegisterType<Company.Core.App.Services.Data.Interfaces.IProductDataService, Company.Core.App.Services.Data.ProductDataService>(RegistrationType.Singleton);



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


            Current.MainWindow = new Company.Project.UI.MainWindow();
            Current.MainWindow.Show();

            base.OnStartup(e);

#if DEBUG
            new TestData();
#endif

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