using System.Collections.Generic;

namespace TeamFormation.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CrestUrl { get; set; }
        public dynamic _links { get; set; }
    }

    public class LeagueModel
    {
        public LeagueModel()
        {
            Teams = new List<TeamModel>();
        }

        public int Count { get; set; }
        public List<TeamModel> Teams { get; set; }
    }
}
