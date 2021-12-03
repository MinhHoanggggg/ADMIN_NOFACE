using Newtonsoft.Json;
using NOFACE_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NOFACE_ADMIN.Controllers
{
    public class UserController : Controller
    {
        public static List<Post> posts;
        public string url = "http://noface.somee.com/";

        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var lstUser = GetAllUser_API().Result;
            return View((List<User>)lstUser);
        }

        [HttpGet]
        public ActionResult Post(string idUser)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var posts = GetAllPost_API(idUser).Result;
            ViewBag.ListPost = posts;
            return View((List<Post>)ViewBag.ListPost);
        }

        public ActionResult Comment(string idUser)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var cmts = GetAllCmt_API(idUser).Result;

            ViewBag.CmtsModel = cmts;
            return View((List<Comment>)ViewBag.CmtsModel);
        }

        public ActionResult DeleteCmt(int idCmt)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var rs = DeleteCmt_API(idCmt).Result;

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BanUser(string idUser)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var rs = Ban_API(idUser).Result;
            if (rs == 1)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UnblockUser(string idUser)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var rs = Unblock_API(idUser).Result;
            if (rs == 1)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeletePost(int idPost)
        {
            var result = DeletePost_API(idPost).Result;
            if (result == 1)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        //========================================call API========================================
        async Task<List<User>> GetAllUser_API()
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
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
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

        async Task<List<Ban>> GetBan_API()
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                var response = await client.GetAsync("get-ban-user").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    List<Ban> lstBan = JsonConvert.DeserializeObject<List<Ban>>(result);
                    return lstBan;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

        async Task<int> Ban_API(string idUser)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                string param = "block-user/" + idUser;

                var response = await client.GetAsync(param).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    Message rs = JsonConvert.DeserializeObject<Message>(result);
                    return rs.Status;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return 0;
        }

        async Task<int> Unblock_API(string idUser)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                string param = "unblock-user/" + idUser;

                var response = await client.GetAsync(param).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    Message rs = JsonConvert.DeserializeObject<Message>(result);
                    return rs.Status;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return 0;
        }

        async Task<List<Post>> GetAllPost_API(string idUser)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
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

        async Task<List<Comment>> GetAllCmt_API(string idUser)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                string param = "get-all-cmt-user/" + idUser;

                var response = await client.GetAsync(param).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    List<Comment> lstCmt = JsonConvert.DeserializeObject<List<Comment>>(result);
                    return lstCmt;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

        async Task<Post> GetPost_API(int idPost)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                string param = "get-post-by-id/" + idPost;
                var response = await client.GetAsync(param).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    Post Post = JsonConvert.DeserializeObject<Post>(result);
                    return Post;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

        async Task<int> DeletePost_API(int idPost)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                string param = "delete-post/" + idPost;

                var response = await client.DeleteAsync(param).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    Message rs = JsonConvert.DeserializeObject<Message>(result);
                    return rs.Status;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return 0;
        }

        async Task<int> DeleteCmt_API(int idCmt)
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                string param = "delete-cmt/" + idCmt;

                var response = await client.DeleteAsync(param).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    Message rs = JsonConvert.DeserializeObject<Message>(result);
                    return rs.Status;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return 0;
        }
    }
}