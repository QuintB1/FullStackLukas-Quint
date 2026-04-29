using ChampionsLeague.Domain.EntitiesDB;

namespace ChampionsLeague.ViewModels
{
    public class OrderLineVM
    {
        public ProductVM productVM {  get; set; }
        public decimal? StaticUnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int LineId { get; set; }
    }
}
