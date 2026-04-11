namespace ChampionsLeague.ViewModels
{
    public class MatchVM
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string HomeClubName { get; set; }
        public string AwayClubName { get; set; }
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }
        public int StadiumId { get; set; }

    }
}
