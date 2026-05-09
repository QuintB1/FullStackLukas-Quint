namespace ChampionsLeague.ViewModels
{
    public class SubscriptionAssignmentVM
    {
        public int AssignmentId { get; set; }
        public string Type => "Subscription";
        public string SectionName { get; set; }
        public int SeatNumber { get; set; }
        public DateOnly SeasonStart { get; set; }
        public DateOnly SeasonEnd { get; set; }
        public string ProductName { get; set; }


    }


}
