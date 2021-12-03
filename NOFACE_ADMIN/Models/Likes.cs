namespace NOFACE_ADMIN.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Likes
    {
        public int ID { get; set; }

        public int IDPost { get; set; }

        [Required]
        [StringLength(50)]
        public string IDUser { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
