using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public class InsuranceService : BaseService
    {
        public InsuranceService(string key) : base(key) { }
        #region "Insurance"
        public Insurance Create(string to_address_id, string from_address_id, string tracking_code, string carrier, string reference, string amount)
        {
            string body = "";
            AppendVariable("insurance[to_address][id]", to_address_id, true, ref body);
            AppendVariable("insurance[from_address][id]", from_address_id, true, ref body);
            AppendVariable("insurance[tracking_code]", tracking_code, true, ref body);
            AppendVariable("insurance[carrier]", carrier, true, ref body);
            AppendVariable("insurance[reference]", reference, true, ref body);
            AppendVariable("insurance[amount]", amount, true, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("insurances", GetBody(body)).Result;
            return response.Content.ReadAsAsync<Insurance>().Result;
        }
        public Insurances List(string before_id, string after_id, DateTime? start_datetime, DateTime? end_datetime, int? page_size)
        {
            string body = "";
            AppendVariable("before_id", before_id, false, ref body);
            AppendVariable("after_id", after_id, false, ref body);
            AppendVariable("start_datetime", start_datetime, false, ref body);
            AppendVariable("end_datetime", end_datetime, false, ref body);
            AppendVariable("page_size", page_size, false, ref body);

            var client = GetHttpClient();
            var response = client.GetAsync("insurances" + "?" + body).Result;
            return response.Content.ReadAsAsync<Insurances>().Result;
        }
        public Insurance Get(string id)
        {
            var client = GetHttpClient();
            var response = client.GetAsync("insurances/" + id).Result;
            return response.Content.ReadAsAsync<Insurance>().Result;
        }
        #endregion

    }
}
