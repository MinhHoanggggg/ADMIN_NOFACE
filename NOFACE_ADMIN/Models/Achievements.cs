namespace NOFACE_ADMIN.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Achievements
    {
        [Key]
        public int ID_Achievements { get; set; }

        [StringLength(50)]
        public string IDUser { get; set; }

        public int? IDMedal { get; set; }

        public virtual Medals Medals { get; set; }

        public virtual User User { get; set; }
    }
}
