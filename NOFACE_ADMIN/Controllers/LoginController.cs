using Newtonsoft.Json;
using NOFACE_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NOFACE_ADMIN.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["AD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (string.IsNullOrEmpty(password))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                try
                {
                    Admin admin = new Admin
                    {
                        UserAdmin = username,
                        PassAdmin = password,
                        HoTen = ""
                    };
                    Message message = TokenAdmin_API(admin).Result;
                    //Gán giá trị cho đối tượng được tạo mới(ad)
                    if (message.Notification != null)
                    {
                        Session["token"] = message.Notification;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewData["Loi3"] = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                catch (Exception)
                {
                    ViewData["Loi3"] = "Lỗi gòi";
                }
            }
            return View();
        }

        async Task<Message> TokenAdmin_API(Admin admin)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://apinoface.somee.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            var response = await client.PostAsync("get-token-admin", stringContent).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                dynamic result = await response.Content.ReadAsStringAsync();

                Message token = JsonConvert.DeserializeObject<Message>(result);
                if(token.Status == 1)
                {
                    return token;
                }
                return null;
            }
            return null;
        }
    }
}