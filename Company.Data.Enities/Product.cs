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
    [Table("Product")]
    public class Product : IEntity
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }


        [Required]
        public int OwnerId { get; set; }

        public virtual Customer Owner { get; set; }
    }
}
