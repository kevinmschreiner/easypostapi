using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public class AddressService:BaseService
    {
        public AddressService(string key) : base(key) { }
        #region "Addresses"
        public Address Create(Address address)
        {
            string body = "";
            AppendVariable("address[street1]", address.street1, true, ref body);
            AppendVariable("address[street2]", address.street2, false, ref body);
            AppendVariable("address[city]", address.city, true, ref body);
            AppendVariable("address[state]", address.state, true, ref body);
            AppendVariable("address[zip]", address.zip, true, ref body);
            AppendVariable("address[country]", address.country, true, ref body);
            AppendVariable("address[name]", address.name, false, ref body);
            AppendVariable("address[company]", address.company, false, ref body);
            AppendVariable("address[phone]", address.phone, false, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("addresses", GetBody(body)).Result;
            return response.Content.ReadAsAsync<Address>().Result;
        }

        public Address Get(string id)
        {
            var client = GetHttpClient();
            var response = client.GetAsync("addresses/" + id).Result;
            return response.Content.ReadAsAsync<Address>().Result;
        }

        public Address Verify(Address address, bool strict)
        {
            string body = "";
            if (strict)
            {
                AppendVariable("verify_strict[]", "delivery", true, ref body);
            }
            else
            {
                AppendVariable("verify[]", "delivery", true, ref body);
            }
            AppendVariable("address[street1]", address.street1, true, ref body);
            AppendVariable("address[street2]", address.street2, false, ref body);
            AppendVariable("address[city]", address.city, true, ref body);
            AppendVariable("address[state]", address.state, true, ref body);
            AppendVariable("address[zip]", address.zip, true, ref body);
            AppendVariable("address[country]", address.country, true, ref body);
            AppendVariable("address[name]", address.name, false, ref body);
            AppendVariable("address[company]", address.company, false, ref body);
            AppendVariable("address[phone]", address.phone, false, ref body);

            var client = GetHttpClient();
            var response = client.PostAsync("addresses", GetBody(body)).Result;
            return response.Content.ReadAsAsync<Address>().Result;
        }
        #endregion

    }
}
