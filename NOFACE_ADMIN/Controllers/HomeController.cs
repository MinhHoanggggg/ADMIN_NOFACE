using Newtonsoft.Json;
using NOFACE_ADMIN.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NOFACE_ADMIN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public JsonResult GetStatistic()
        {
            Statistics statistics = GetStatistic_API().Result;
            SumStatistics sumStatistics = GetSumStatistic_API().Result;

            if (statistics != null && sumStatistics != null)
            {
                return Json(new { success = true, statistics.Posts, statistics.Users, sumStatistics}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }


        async Task<Statistics> GetStatistic_API()
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri("http://noface.somee.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                var response = await client.GetAsync("get-Statistics").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    Statistics statistics = JsonConvert.DeserializeObject<Statistics>(result);
                    return statistics;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine();
            }
            return null;
        }

        async Task<SumStatistics> GetSumStatistic_API()
        {
            try
            {
                var client = new HttpClient();
                string accessToken = (string)Session["token"];
                client.BaseAddress = new Uri("http://noface.somee.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                var response = await client.GetAsync("get-SumStatistics").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsStringAsync();
                    SumStatistics SumStatistics = JsonConvert.DeserializeObject<SumStatistics>(result);
                    return SumStatistics;
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