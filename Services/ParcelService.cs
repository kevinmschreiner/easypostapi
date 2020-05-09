using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public class ParcelService : BaseService
    {
        public ParcelService(string key) : base(key) { }
        #region "Parcels"
        public Parcel Create(Parcel parcel)
        {
            string body = "";
            AppendVariable("parcel[length]", parcel.length, true, ref body);
            AppendVariable("parcel[width]", parcel.width, false, ref body);
            AppendVariable("parcel[height]", parcel.height, true, ref body);
            AppendVariable("parcel[weight]", parcel.weight, true, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("parcels", GetBody(body)).Result;
            return response.Content.ReadAsAsync<Parcel>().Result;
        }
        public Parcel Get(string id)
        {
            var client = GetHttpClient();
            var response = client.GetAsync("parcels/" + id).Result;
            return response.Content.ReadAsAsync<Parcel>().Result;
        }
        #endregion

    }
}
