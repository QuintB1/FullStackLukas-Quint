using ChampionsLeague.Domain.EntitiesDB;

namespace ChampionsLeague.ViewModels
{
    public class OrderLineVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? StaticUnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int LineId { get; set; }
    }
}
