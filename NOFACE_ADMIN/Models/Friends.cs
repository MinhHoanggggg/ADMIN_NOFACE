namespace NOFACE_ADMIN.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Friends
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string IDUser { get; set; }

        [StringLength(50)]
        public string IDFriends { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
