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
    public class UserController : Controller
    {

        public ActionResult index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var lstUser = GetAllUser_API().Result;
            ViewBag.UsersModel = lstUser;
            return View((List<User>)ViewBag.UsersModel);
        }

        [HttpPost]
        public ActionResult Posts(string idUser)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var lstPost = GetAllPost_API(idUser).Result;
            ViewBag.PostsModel = lstPost;
            return RedirectToAction("Posts", "User");
        }

        [HttpGet]
        public ActionResult Posts(List<Post> posts)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //var lstPost = GetAllPost_API(idUser).Result;
            ViewBag.PostsModel = posts;
            return View((List<Post>)ViewBag.PostsModel);
        }

        //========================================call API========================================
        async Task<List<User>> GetAllUser_API()
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri("http://apinoface.somee.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                var response = await client.GetAsync("get-all-user").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    List<User> lstUser = JsonConvert.DeserializeObject<List<User>>(result);
                    return lstUser;
                }
            }
            catch(Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

        async Task<List<Post>> GetAllPost_API(string idUser)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri("http://apinoface.somee.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                string param = "get-all-post-by-user/" + idUser;
                var response = await client.GetAsync(param).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    List<Post> lstPost = JsonConvert.DeserializeObject<List<Post>>(result);
                    return lstPost;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

    }
}