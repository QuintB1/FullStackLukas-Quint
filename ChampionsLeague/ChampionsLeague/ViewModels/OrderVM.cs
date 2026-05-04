namespace ChampionsLeague.ViewModels
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public DateOnly OrderDate { get; set; }
        public List<OrderLineVM> OrderLines { get; set; }
    }
}
