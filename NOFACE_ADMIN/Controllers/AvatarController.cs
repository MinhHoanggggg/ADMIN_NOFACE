using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using NOFACE_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NOFACE_ADMIN.Controllers
{
    public class AvatarController : Controller
    {
        public ActionResult Index()
        {
            var MyList = new List<Avt>();
            {
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava1.png?alt=media&token=afb84a62-63fc-4719-bf94-2f2b01fc03d9"));
                    MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava10.png?alt=media&token=b451b4a9-2a22-489a-a5a0-1d5476792810"));
                    MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava2.png?alt=media&token=4fce9ac2-60e0-4424-af17-a525a7655f40"));
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava3.png?alt=media&token=fd0589f9-5eaa-4fa7-a4f6-0c8be89ca977"));
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava4.png?alt=media&token=e3e081de-6ade-4390-935d-fbd1d8cb3066"));
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava5.png?alt=media&token=7b7d861a-0a2b-48e2-b9c7-4258f94daa17"));
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava6.png?alt=media&token=38458a90-a23e-49cb-b242-72a8f6ef667d"));
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava7.png?alt=media&token=f8b19d89-bbe9-4053-9494-822fc04318ca"));
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava8.png?alt=media&token=3ba8d40a-bd15-4fa0-9c51-cff70558b0d5"));
                MyList.Add(new Avt("https://firebasestorage.googleapis.com/v0/b/noface-2e0d0.appspot.com/o/avatars%2Fava9.png?alt=media&token=6ebb6cac-0a4d-4e54-896e-6c87d1f27138"));
            }
            return View((List<Avt>)MyList);
        }
    }
}