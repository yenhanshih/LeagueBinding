using System.Collections.Generic;
using LeagueBinding.Client.Common;

namespace LeagueBinding.Client.ViewModels.Bases.Interfaces
{
    public interface ISelectBindingViewModel
    {
        string SelectedPageName { get; set; }
        List<string> PageNames { get; set; }

        RelayCommand Set { get; }
    }
}