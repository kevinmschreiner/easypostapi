using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public class ShipmentService:BaseService
    {
        public ShipmentService(string key) : base(key) { }
        #region "Shipments"
        public Shipment Create(Address to_address, Address from_address, Parcel parcel, CustomsInfo customs_info)
        {
            string body = "";
            AppendVariable("shipment[to_address]", to_address, true, ref body);
            AppendVariable("shipment[from_address]", from_address, true, ref body);
            AppendVariable("shipment[parcel]", parcel, true, ref body);
            AppendVariable("shipment[customs_info]", customs_info, false, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("shipments", GetBody(body)).Result;
            return response.Content.ReadAsAsync<Shipment>().Result;
        }
        public Shipment Create(Address to_address, Address from_address, Parcel parcel, CustomsInfo customs_info, Options options)
        {
            string body = "";
            AppendVariable("shipment[to_address]", to_address, true, ref body);
            AppendVariable("shipment[from_address]", from_address, true, ref body);
            AppendVariable("shipment[parcel]", parcel, true, ref body);
            AppendVariable("shipment[customs_info]", customs_info, false, ref body);
            AppendVariable("shipment[options]", options, false, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("shipments", GetBody(body)).Result;
            return response.Content.ReadAsAsync<Shipment>().Result;
        }
        public Shipments List(string before_id, string after_id, DateTime? start_datetime, DateTime? end_datetime, int? page_size, bool? purchased, bool? include_children)
        {
            string body = "";
            AppendVariable("before_id", before_id, false, ref body);
            AppendVariable("after_id", after_id, false, ref body);
            AppendVariable("start_datetime", start_datetime, false, ref body);
            AppendVariable("end_datetime", end_datetime, false, ref body);
            AppendVariable("page_size", page_size, false, ref body);
            AppendVariable("purchased", purchased, false, ref body);
            AppendVariable("include_children", include_children, false, ref body);

            var client = GetHttpClient();
            var response = client.GetAsync("shipments" + "?" + body).Result;
            return response.Content.ReadAsAsync<Shipments>().Result;
        }
        public Shipment Get(string id)
        {
            var client = GetHttpClient();
            var response = client.GetAsync("shipments/" + id).Result;
            return response.Content.ReadAsAsync<Shipment>().Result;
        }
        #endregion

    }
}
