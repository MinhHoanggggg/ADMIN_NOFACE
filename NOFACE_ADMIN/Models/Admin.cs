namespace NOFACE_ADMIN.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(30)]
        public string UserAdmin { get; set; }

        [Required]
        [StringLength(30)]
        public string PassAdmin { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }
    }
}
