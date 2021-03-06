namespace NOFACE_ADMIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comment = new HashSet<Comment>();
            Likes = new HashSet<Likes>();
        }

        [Key]
        public int IDPost { get; set; }

        public int? IDTopic { get; set; }

        [StringLength(50)]
        public string IDUser { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Time { get; set; }

        public string ImagePost { get; set; }

        public int? Views { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes> Likes { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual User User { get; set; }
    }
}
