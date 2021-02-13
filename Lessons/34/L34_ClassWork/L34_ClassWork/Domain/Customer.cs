using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L34_ClassWork.Domain
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("Name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }
    }

}
