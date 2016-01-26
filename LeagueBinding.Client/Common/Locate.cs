using System;
using System.Windows.Markup;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;
using LightInject;

namespace LeagueBinding.Client.Common
{
    [MarkupExtensionReturnType(typeof(Locate))]
    public sealed class Locate
        : MarkupExtension
    {
        private static readonly Locate Locator = new Locate();
        private readonly IServiceFactory _container;

        public Locate()
        {
            _container = Ioc.Container;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Locator;
        }

        public IMainViewModel MainViewModel
        {
            get { return _container.GetInstance<IMainViewModel>(); }
        }

        public ISelectBindingViewModel SelectBindingViewModel
        {
            get { return _container.GetInstance<ISelectBindingViewModel>(); }
        }

        public IAddBindingViewModel AddBindingViewModel
        {
            get { return _container.GetInstance<IAddBindingViewModel>(); }
        }

        public IEditBindingViewModel EditBindingViewModel
        {
            get { return _container.GetInstance<IEditBindingViewModel>(); }
        }

        public ISettingsViewModel SettingsViewModel
        {
            get { return _container.GetInstance<ISettingsViewModel>(); }
        }

        public IConfirmFolderDialogViewModel ConfirmFolderDialogViewModel
        {
            get { return _container.GetInstance<IConfirmFolderDialogViewModel>(); }
        }

        public ICreatedDialogViewModel CreatedDialogViewModel
        {
            get { return _container.GetInstance<ICreatedDialogViewModel>(); }
        }

        public IFileExistsDialogViewModel FileExistsDialogViewModel
        {
            get { return _container.GetInstance<IFileExistsDialogViewModel>(); }
        }
    }
}