namespace NOFACE_ADMIN.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LikeComment")]
    public partial class LikeComment
    {
        [Key]
        public int ID_Like_Comment { get; set; }

        public int? IDCmt { get; set; }

        [StringLength(50)]
        public string IDUser { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual User User { get; set; }
    }
}
