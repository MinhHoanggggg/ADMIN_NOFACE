namespace NOFACE_ADMIN.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Medals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medals()
        {
            Achievements = new HashSet<Achievements>();
        }

        [Key]
        public int IDMedal { get; set; }

        [StringLength(200)]
        public string MedalName { get; set; }

        [StringLength(50)]
        public string ImgMedal { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Achievements> Achievements { get; set; }
    }
}
