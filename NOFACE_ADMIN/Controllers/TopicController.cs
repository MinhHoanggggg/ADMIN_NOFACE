using Newtonsoft.Json;
using NOFACE_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NOFACE_ADMIN.Controllers
{
    public class TopicController : Controller
    {
        public string url = "http://noface.somee.com/";

        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var lstTopic = GetAllTopic_API().Result;

            return View(lstTopic);
        }

        public ActionResult AddTopic(Topic topic)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var rs = AddTopic_API(topic).Result;

            if (rs == 1)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateTopic(Topic topic)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var rs = UpdateTopic_API(topic).Result;

            if (rs == 1)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        //api
        async Task<List<Topic>> GetAllTopic_API()
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
                var response = await client.GetAsync("get-all-topic").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    List<Topic> lstTopic = JsonConvert.DeserializeObject<List<Topic>>(result);
                    return lstTopic;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

        async Task<int> AddTopic_API(Topic topic)
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

                var content = new StringContent(JsonConvert.SerializeObject(topic), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("add-topic",content).ConfigureAwait(false);
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

        async Task<int> UpdateTopic_API(Topic topic)
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

                var content = new StringContent(JsonConvert.SerializeObject(topic), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("update-topic", content).ConfigureAwait(false);
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