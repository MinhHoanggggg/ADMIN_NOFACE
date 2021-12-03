namespace NOFACE_ADMIN.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ban")]
    public partial class Ban
    {
        [Key]
        public int IDBan { get; set; }

        [Required]
        [StringLength(50)]
        public string IDUser { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TimeBan { get; set; }

        public virtual User User { get; set; }
    }
}
