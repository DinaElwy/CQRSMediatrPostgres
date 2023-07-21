using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediatr.PostgresEFCore
{
    [Table("order")]
    public class Order
    {
        [Key,Required]
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }    
        public string Name { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
