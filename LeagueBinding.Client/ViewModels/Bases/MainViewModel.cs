using System.Linq;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;

namespace LeagueBinding.Client.ViewModels.Bases
{
    public class MainViewModel
        : BaseViewModel
        , IMainViewModel
    {
        private readonly IDataManager _dataManager;

        public bool IsSelectSelected
        {
            set
            {
                if (value)
                {
                    var model = Ioc.Container.GetInstance<ISelectBindingViewModel>();
                    model.PageNames = _dataManager.GetAllPageNames();
                }
            }
        }

        public bool IsEditSelected
        {
            set
            {
                if (value)
                {
                    var model = Ioc.Container.GetInstance<IEditBindingViewModel>();
                    model.PageNames = _dataManager.GetAllPageNames().ToList();
                }
            }
        }

        public IModalManager ModalManager { get; private set; }

        public MainViewModel(IDataManager dataManager, IModalManager modalManager)
        {
            _dataManager = dataManager;

            ModalManager = modalManager;
        }
    }
}
