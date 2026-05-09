namespace ChampionsLeague.Models
{
    public class HotelBooking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

    }
}
