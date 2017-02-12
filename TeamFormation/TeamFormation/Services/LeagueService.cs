using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamFormation.Models;

namespace TeamFormation.Services
{
    public interface ILeagueService
    {
        Task<List<TeamModel>> GetTeams();
    }

    public class LeagueService : ILeagueService
    {
        private readonly IDataService _dataService;

        public LeagueService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public LeagueService()
        {
            _dataService = new DataService();
        }

        public async Task<List<TeamModel>> GetTeams()
        {
            var league = await _dataService.GetData<LeagueModel>("http://api.football-data.org/v1/competitions/426/teams");

            Debug.WriteLine(league);

            if (league != null)
            {
                Debug.WriteLine(league.Teams.Count);
                return league.Teams;
            }

            return Enumerable.Empty<TeamModel>().ToList();
        }
    }
}
