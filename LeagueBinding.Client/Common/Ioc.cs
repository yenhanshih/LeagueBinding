using LeagueBinding.Client.Manager;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.ViewModels.Bases;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;
using LightInject;

namespace LeagueBinding.Client.Common
{
    public static class Ioc
    {
        public static IServiceFactory Container { get; private set; }

        static Ioc()
        {
            Container = RegisterTypes();
        }

        private static ServiceContainer RegisterTypes()
        {
            var container = new ServiceContainer();
            container.Register<IDataManager, DataManager>(new PerContainerLifetime());
            container.Register<IModalManager, ModalManager>(new PerContainerLifetime());

            container.Register<IMainViewModel, MainViewModel>(new PerContainerLifetime());
            container.Register<ISelectBindingViewModel, SelectBindingViewModel>(new PerContainerLifetime());
            container.Register<IAddBindingViewModel, AddBindingViewModel>(new PerContainerLifetime());
            container.Register<IEditBindingViewModel, EditBindingViewModel>(new PerContainerLifetime());
            container.Register<ISettingsViewModel, SettingsViewModel>(new PerContainerLifetime());
            container.Register<IConfirmationDialogViewModel, ConfirmationDialogViewModel>(new PerContainerLifetime());

            return container;
        }
    }
}