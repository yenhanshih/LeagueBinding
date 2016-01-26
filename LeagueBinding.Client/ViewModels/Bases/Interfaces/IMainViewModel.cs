using LeagueBinding.Client.Manager.Interfaces;

namespace LeagueBinding.Client.ViewModels.Bases.Interfaces
{
    public interface IMainViewModel
    {
        bool IsSelectSelected { set; }
        bool IsEditSelected { set; }
        IModalManager ModalManager { get; }
    }
}