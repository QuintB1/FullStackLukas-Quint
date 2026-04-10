namespace ChampionsLeague.ViewModels
{
    public class OrderVM
    {
        public DateOnly OrderDate { get; set; }
        public List<OrderLineVM> OrderLines { get; set; }
    }
}
