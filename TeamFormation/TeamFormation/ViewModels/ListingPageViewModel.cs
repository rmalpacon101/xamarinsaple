using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;
using TeamFormation.Models;
using TeamFormation.Services;

namespace TeamFormation.ViewModels
{
    public class ListingPageViewModel : BindableBase, INavigationAware
    {
        private readonly ILeagueService _leagueService;

        private ObservableCollection<TeamModel> _teamCollection;

        public ObservableCollection<TeamModel> TeamCollection
        {
            get { return _teamCollection; }
            set { SetProperty(ref _teamCollection, value); }
        }

        public ListingPageViewModel(ILeagueService leagueService)
        {
            _leagueService = leagueService; 
        }
        
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Task.Run(async () =>
            {
                TeamCollection = new ObservableCollection<TeamModel>(await _leagueService.GetTeams());

                Debug.WriteLine(TeamCollection[0].Name);
            });
        }
    }
}
