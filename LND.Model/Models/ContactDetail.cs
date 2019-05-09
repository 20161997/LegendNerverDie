using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LND.Model.Models
{
    [Table("ContactDetails")]
    public class ContactDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Address { set; get; }
        [StringLength(50)]
        public string Email { set; get; }
        [StringLength(50)]
        public string Website { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool Status { get; set; }
    }
}