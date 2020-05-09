using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public class TrackerService:BaseService
    {
        public TrackerService(string key) : base(key) { }
        #region "Tracker"
        public Tracker Create(string tracking_code, string carrier)
        {
            string body = "";
            AppendVariable("tracker[tracking_code]", tracking_code, true, ref body);
            AppendVariable("tracker[carrier]", carrier, true, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("trackers", GetBody(body)).Result;
            return response.Content.ReadAsAsync<Tracker>().Result;
        }
        public Trackers List(string before_id, string after_id, DateTime? start_datetime, DateTime? end_datetime, int? page_size, string tracking_code, string carrier)
        {
            string body = "";
            AppendVariable("before_id", before_id, false, ref body);
            AppendVariable("after_id", after_id, false, ref body);
            AppendVariable("start_datetime", start_datetime, false, ref body);
            AppendVariable("end_datetime", end_datetime, false, ref body);
            AppendVariable("page_size", page_size, false, ref body);
            AppendVariable("tracking_code", tracking_code, false, ref body);
            AppendVariable("carrier", carrier, false, ref body);

            var client = GetHttpClient();
            var response = client.GetAsync("trackers" + "?" + body).Result;
            return response.Content.ReadAsAsync<Trackers>().Result;
        }
        public Tracker Get(string id)
        {
            var client = GetHttpClient();
            var response = client.GetAsync("trackers/" + id).Result;
            return response.Content.ReadAsAsync<Tracker>().Result;
        }
        #endregion

    }
}
