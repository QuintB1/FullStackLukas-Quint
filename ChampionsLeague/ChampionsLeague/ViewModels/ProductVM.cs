namespace ChampionsLeague.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;
        public int ProductId { get; set; }
        public decimal DynamicUnitPrice { get; set; }

    }
}
