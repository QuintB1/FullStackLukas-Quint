namespace ChampionsLeague.ViewModels
{
    public class StadiumSectionVM
    {
        public int SectionId { get; set; }

        public string Name { get; set; } = null!;

        public int Capacity { get; set; }
        public int ClubId { get; set; }
    }
}
