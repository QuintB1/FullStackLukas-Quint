namespace ChampionsLeague.ViewModels
{
    public class TicketAssignmentVM
    {
        public int AssignmentId { get; set; }
        public string Type => "Ticket";
        public string SectionName { get; set; }
        public int SeatNumber { get; set; }
        public DateTime MatchDate { get; set; }
        public string ProductName { get; set; }



    }


}
