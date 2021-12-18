using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOFACE_ADMIN.Models
{
    public class Notification
    {
        public Notification(int iD_Notification, string iD_User, string data_Notification, int? iDPost, string iD_User_Seen_noti, int status_Notification, Post post, User user)
        {
            ID_Notification = iD_Notification;
            ID_User = iD_User;
            Data_Notification = data_Notification;
            IDPost = iDPost;
            ID_User_Seen_noti = iD_User_Seen_noti;
            Status_Notification = status_Notification;
            Post = post;
            User = user;
        }

        public int ID_Notification { get; set; }

        public string ID_User { get; set; }


        public string Data_Notification { get; set; }

        public int? IDPost { get; set; }

        public string ID_User_Seen_noti { get; set; }

        public int Status_Notification { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}