namespace NOFACE_ADMIN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
