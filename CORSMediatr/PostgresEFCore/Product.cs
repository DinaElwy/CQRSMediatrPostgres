using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediatr.PostgresEFCore
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
