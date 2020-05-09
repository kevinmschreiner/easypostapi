using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public class PickupService : BaseService
    {
        public PickupService(string key) : base(key) { }

        #region "Pickups"
        public PickUp Create(string reference, DateTime min_datetime, DateTime max_datetime, Shipment shipment, Address address, bool is_account_address, string instructions)
        {
            string body = "";
            AppendVariable("pickup[reference]", reference, false, ref body); ;
            AppendVariable("pickup[min_datetime]", min_datetime, false, ref body); ;
            AppendVariable("pickup[max_datetime]", max_datetime, false, ref body); ;
            AppendVariable("pickup[shipment]", shipment, false, ref body);
            AppendVariable("pickup[address]", address, false, ref body);
            AppendVariable("pickup[is_account_address]", is_account_address, false, ref body);
            AppendVariable("pickup[instructions]", instructions, false, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("pickups", GetBody(body)).Result;
            return response.Content.ReadAsAsync<PickUp>().Result;
        }
        public PickUp Get(string id)
        {
            var client = GetHttpClient();
            var response = client.GetAsync("pickups/" + id).Result;
            return response.Content.ReadAsAsync<PickUp>().Result;
        }

        public PickUp Buy(string id, string carrier, string service)
        {
            string body = "";
            AppendVariable("carrier", carrier, false, ref body); ;
            AppendVariable("service", service, false, ref body); ;

            var client = GetHttpClient();
            var response = client.PostAsync("pickups/" + id + "/buy", GetBody(body)).Result;
            return response.Content.ReadAsAsync<PickUp>().Result;
        }


        public PickUp Cancel(string id)
        {
            string body = "";
            var client = GetHttpClient();
            var response = client.PostAsync("pickups/" + id + "/cancel", GetBody(body)).Result;
            return response.Content.ReadAsAsync<PickUp>().Result;
        }
        #endregion

    }
}
