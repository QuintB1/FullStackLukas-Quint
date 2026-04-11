using ChampionsLeague.Domain.EntitiesDB;

namespace ChampionsLeague.ViewModels
{
    public class OrderLineVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
