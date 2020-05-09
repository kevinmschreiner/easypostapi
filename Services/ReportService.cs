using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public class ReportService : BaseService
    {
        public ReportService(string key) : base(key) { }
        #region "Reports"
        public Report Create(string category, DateTime? start_date, DateTime? end_date, bool send_email)
        {
            string body = "{\"start_date\":\"" + start_date.Value.ToString("yyyy-MM-dd") + "\",\"end_date\":\"" + end_date.Value.ToString("yyyy-MM-dd") + "\"" + (send_email ? ",\"send_email\":true" : "") + "}";
            var client = GetHttpClient();
            var response = client.PostAsync("reports/" + category, GetBody(body, "Application/json")).Result;
            return response.Content.ReadAsAsync<Report>().Result;
        }
        public Reports List(string category, string before_id, string after_id, DateTime? start_date, DateTime? end_date, int? page_size)
        {
            string body = "";
            AppendVariable("before_id", before_id, false, ref body);
            AppendVariable("after_id", after_id, false, ref body);
            AppendVariable("start_date", start_date, false, ref body, true);
            AppendVariable("end_date", end_date, false, ref body, true);
            AppendVariable("page_size", page_size, false, ref body);

            var client = GetHttpClient();
            var response = client.GetAsync("reports/" + category + "?" + body).Result;
            return response.Content.ReadAsAsync<Reports>().Result;
        }
        public Report Get(string category, string id)
        {
            var client = GetHttpClient();
            var response = client.GetAsync("reports/" + category + "/" + id).Result;
            return response.Content.ReadAsAsync<Report>().Result;
        }
        #endregion

    }
}
