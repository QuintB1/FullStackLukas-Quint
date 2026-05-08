namespace ChampionsLeague.ViewModels
{
    public class MatchVM
    {
        public int MatchId { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string HomeClubName { get; set; }
        public string AwayClubName { get; set; }
        public string StadiumName {  get; set; }

    }
}
