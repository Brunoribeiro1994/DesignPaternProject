using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.Mysql.Model
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; }
        [Column("product_name")]
        [Required]
        [StringLength(50)]
        public string Name { get; private set; }
        [Column("product_description")]
        [Required]
        [StringLength(255)]
        public string Description { get; private set; }
        [Column("product_quantity", TypeName="int")]
        [Required]
        public int Quantity { get; private set; }
        [Column("product_price")]
        [Required]
        [Range(1,10000)]
        public decimal Price { get; private set; }
        [Column("product_image")]
        [Required]
        [StringLength(255)]
        public string LinkPhoto { get; private set; }
        [Column("product_data", TypeName ="datetime")]
        public DateTime CreatedAt { get; private set; }
    }
}
