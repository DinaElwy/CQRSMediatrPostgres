namespace CQRSMediatr.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
