using Company.Data.If;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Enities
{
    [Table("Customer")]
    public class Customer : IEntity
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string CustomerNumber { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
