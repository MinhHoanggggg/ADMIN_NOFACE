namespace NOFACE_ADMIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Achievements = new HashSet<Achievements>();
            Ban = new HashSet<Ban>();
            Comment = new HashSet<Comment>();
            Friends = new HashSet<Friends>();
            Friends1 = new HashSet<Friends>();
            LikeComment = new HashSet<LikeComment>();
            Likes = new HashSet<Likes>();
            Post = new HashSet<Post>();
        }

        [Key]
        [StringLength(50)]
        public string IDUser { get; set; }

        public string Name { get; set; }

        public string Avt { get; set; }

        public string RefeshToken { get; set; }

        public int? Warning { get; set; }

        public int? Activated { get; set; }


        [Column(TypeName = "smalldatetime")]
        public DateTime? TimeRegister { get; set; }

        public virtual ICollection<Achievements> Achievements { get; set; }

        public virtual ICollection<Ban> Ban { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

        public virtual ICollection<Friends> Friends { get; set; }

        public virtual ICollection<Friends> Friends1 { get; set; }

        public virtual ICollection<LikeComment> LikeComment { get; set; }

        public virtual ICollection<Likes> Likes { get; set; }

        public virtual ICollection<Post> Post { get; set; }

    }
}
