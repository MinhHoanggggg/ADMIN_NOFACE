namespace NOFACE_ADMIN.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Message")]
    public partial class Message
    {
        public Message(int status, string notification)
        {
            Status = status;
            Notification = notification;
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Notification { get; set; }
    }
}
