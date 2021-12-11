namespace NOFACE_ADMIN.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Avt")]
    public class Avt
    {
        public Avt(string imgurl)
        {
            Imgurl = imgurl;
        }

        public string Imgurl { get; set; }
    }
}
