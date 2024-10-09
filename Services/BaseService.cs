using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light.Services
{
    public abstract class BaseService
    {
        private const string url = "https://api.easypost.com/v2/";
        private string key;
        public BaseService(string key)
        {
            this.key = key;
        }
        #region "Request Building"
        protected System.Net.Http.HttpClient GetHttpClient() //string url
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", this.key);
            return client;
        }
        protected void AppendVariable(string name, Address value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[name]", value.name, false, ref body);
                    AppendVariable(name + "[company]", value.company, false, ref body);
                    AppendVariable(name + "[street1]", value.street1, false, ref body);
                    AppendVariable(name + "[street2]", value.street2, false, ref body);
                    AppendVariable(name + "[city]", value.city, false, ref body);
                    AppendVariable(name + "[state]", value.state, false, ref body);
                    AppendVariable(name + "[zip]", value.zip, false, ref body);
                    AppendVariable(name + "[country]", value.country, false, ref body);
                    AppendVariable(name + "[phone]", value.phone, false, ref body);
                    AppendVariable(name + "[email]", value.email, false, ref body);
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Parcel value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[length]", value.length, false, ref body);
                    AppendVariable(name + "[width]", value.width, false, ref body);
                    AppendVariable(name + "[height]", value.height, false, ref body);
                    AppendVariable(name + "[weight]", value.weight, false, ref body);
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Options value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                AppendVariable(name + "[additional_handling]", value.additional_handling, false, ref body);
                AppendVariable(name + "[address_validation_level]", value.address_validation_level, false, ref body);
                AppendVariable(name + "[heigalcoholht]", value.alcohol, false, ref body);
                AppendVariable(name + "[billing_ref]", value.billing_ref, false, ref body);
                AppendVariable(name + "[bill_receiver_account]", value.bill_receiver_account, false, ref body);
                AppendVariable(name + "[bill_receiver_postal_code]", value.bill_receiver_postal_code, false, ref body);
                AppendVariable(name + "[bill_third_party_account]", value.bill_third_party_account, false, ref body);
                AppendVariable(name + "[bill_third_party_country]", value.bill_third_party_country, false, ref body);
                AppendVariable(name + "[bill_third_party_postal_code]", value.bill_third_party_postal_code, false, ref body);
                AppendVariable(name + "[by_drone]", value.by_drone, false, ref body);
                AppendVariable(name + "[carbon_neutral]", value.carbon_neutral, false, ref body);
                AppendVariable(name + "[certified_mail]", value.certified_mail, false, ref body);
                AppendVariable(name + "[cod_address_id]", value.cod_address_id, false, ref body);
                AppendVariable(name + "[cod_amount]", value.cod_amount, false, ref body);
                AppendVariable(name + "[cod_method]", value.cod_method, false, ref body);
                AppendVariable(name + "[currency]", value.currency, false, ref body);
                AppendVariable(name + "[delivery_confirmation]", value.delivery_confirmation, false, ref body);
                AppendVariable(name + "[dropoff_type]", value.dropoff_type, false, ref body);
                AppendVariable(name + "[dry_ice]", value.dry_ice, false, ref body);
                AppendVariable(name + "[dry_ice_medical]", value.dry_ice_medical, false, ref body);
                AppendVariable(name + "[dry_ice_weight]", value.dry_ice_weight, false, ref body);
                AppendVariable(name + "[endorsement]", value.endorsement, false, ref body);
                AppendVariable(name + "[freight_charge]", value.freight_charge, false, ref body);
                AppendVariable(name + "[handling_instructions]", value.handling_instructions, false, ref body);
                AppendVariable(name + "[hazmat]", value.hazmat, false, ref body);
                AppendVariable(name + "[hold_for_pickup]", value.hold_for_pickup, false, ref body);
                AppendVariable(name + "[incoterm]", value.incoterm, false, ref body);
                AppendVariable(name + "[invoice_number]", value.invoice_number, false, ref body);
                AppendVariable(name + "[label_date]", value.label_date, false, ref body);
                AppendVariable(name + "[label_format]", value.label_format, false, ref body);
                AppendVariable(name + "[machinable]", value.machinable, false, ref body);
                AppendVariable(name + "[registered_mail]", value.registered_mail, false, ref body);
                AppendVariable(name + "[registered_mail_amount]", value.registered_mail_amount, false, ref body);
                AppendVariable(name + "[return_receipt]", value.return_receipt, false, ref body);
                AppendVariable(name + "[saturday_delivery]", value.saturday_delivery, false, ref body);
                AppendVariable(name + "[smartpost_hub]", value.smartpost_hub, false, ref body);
                AppendVariable(name + "[smartpost_manifest]", value.smartpost_manifest, false, ref body);
                AppendVariable(name + "[special_rates_eligibility]", value.special_rates_eligibility, false, ref body);
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Form value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[form_type]", value.form_type, false, ref body);
                    AppendVariable(name + "[form_url]", value.form_url, false, ref body);
                    AppendVariable(name + "[submitted_electronically]", value.submitted_electronically, false, ref body);
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, ScanForm value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[address]", value.address, false, ref body);
                    AppendVariable(name + "[batch_id]", value.batch_id, false, ref body);
                    AppendVariable(name + "[form_file_type]", value.form_file_type, false, ref body);
                    AppendVariable(name + "[form_url]", value.form_url, false, ref body);
                    AppendVariable(name + "[message]", value.message, false, ref body);
                    AppendVariable(name + "[status]", value.status, false, ref body);
                    if (value.tracking_codes != null && value.tracking_codes.Length > 0)
                    {
                        for (var i = 0; i < value.tracking_codes.Length; i++)
                        {
                            AppendVariable(name + "[tracking_codes][" + i + "]", value.tracking_codes[i], false, ref body);
                        }
                    }
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Fee value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                AppendVariable(name + "[amount]", value.amount, false, ref body);
                AppendVariable(name + "[charged]", value.charged, false, ref body);
                AppendVariable(name + "[refunded]", value.refunded, false, ref body);
                AppendVariable(name + "[type]", value.type, false, ref body);
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Rate value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[carrier]", value.carrier, false, ref body);
                    AppendVariable(name + "[carrier_account_id]", value.carrier_account_id, false, ref body);
                    AppendVariable(name + "[currency]", value.currency, false, ref body);
                    AppendVariable(name + "[delivery_date]", value.delivery_date, false, ref body);
                    AppendVariable(name + "[delivery_date_guaranteed]", value.delivery_date_guaranteed, false, ref body);
                    AppendVariable(name + "[delivery_days]", value.delivery_days, false, ref body);
                    AppendVariable(name + "[list_currency]", value.list_currency, false, ref body);
                    AppendVariable(name + "[list_rate]", value.list_rate, false, ref body);
                    AppendVariable(name + "[rate]", value.rate, false, ref body);
                    AppendVariable(name + "[retail_currency]", value.retail_currency, false, ref body);
                    AppendVariable(name + "[retail_rate]", value.retail_rate, false, ref body);
                    AppendVariable(name + "[service]", value.service, false, ref body);
                    AppendVariable(name + "[shipment_id]", value.shipment_id, false, ref body);
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, PostageLabel value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[integrated_form]", value.integrated_form, false, ref body);
                    AppendVariable(name + "[label_date]", value.label_date, false, ref body);
                    AppendVariable(name + "[label_epl2_url]", value.label_epl2_url, false, ref body);
                    AppendVariable(name + "[label_file_type]", value.label_file_type, false, ref body);
                    AppendVariable(name + "[label_pdf_url]", value.label_pdf_url, false, ref body);
                    AppendVariable(name + "[label_resolution]", value.label_resolution, false, ref body);
                    AppendVariable(name + "[label_size]", value.label_size, false, ref body);
                    AppendVariable(name + "[label_type]", value.label_type, false, ref body);
                    AppendVariable(name + "[label_url]", value.label_url, false, ref body);
                    AppendVariable(name + "[label_zpl_url]", value.label_zpl_url, false, ref body);
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, TrackingDetail value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                AppendVariable(name + "[datetime]", value.datetime, false, ref body);
                AppendVariable(name + "[message]", value.message, false, ref body);
                AppendVariable(name + "[source]", value.source, false, ref body);
                AppendVariable(name + "[status]", value.status, false, ref body);
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Insurance value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                AppendVariable(name + "[amount]", value.amount, false, ref body);
                AppendVariable(name + "[fee]", value.fee, false, ref body);
                AppendVariable(name + "[from_address]", value.from_address, false, ref body);
                AppendVariable(name + "[provider]", value.provider, false, ref body);
                AppendVariable(name + "[provider_id]", value.provider_id, false, ref body);
                AppendVariable(name + "[reference]", value.reference, false, ref body);
                AppendVariable(name + "[shipment_id]", value.shipment_id, false, ref body);
                AppendVariable(name + "[status]", value.status, false, ref body);
                AppendVariable(name + "[to_address]", value.to_address, false, ref body);
                AppendVariable(name + "[tracker]", value.tracker, false, ref body);
                AppendVariable(name + "[tracking_code]", value.tracking_code, false, ref body);
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Tracker value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                AppendVariable(name + "[carrier]", value.carrier, false, ref body);
                if (value.fees != null && value.fees.Length > 0)
                {
                    for (var i = 0; i < value.fees.Length; i++)
                    {
                        AppendVariable(name + "[fees][" + i + "]", value.fees[i], false, ref body);
                    }
                }
                AppendVariable(name + "[est_delivery_date]", value.est_delivery_date, false, ref body);
                AppendVariable(name + "[public_url]", value.public_url, false, ref body);
                AppendVariable(name + "[shipment_id]", value.shipment_id, false, ref body);
                AppendVariable(name + "[status]", value.status, false, ref body);
                AppendVariable(name + "[signed_by]", value.signed_by, false, ref body);
                AppendVariable(name + "[tracking_code]", value.tracking_code, false, ref body);
                if (value.tracking_details != null && value.tracking_details.Length > 0)
                {
                    for (var i = 0; i < value.tracking_details.Length; i++)
                    {
                        AppendVariable(name + "[tracking_details][" + i + "]", value.tracking_details[i], false, ref body);
                    }
                }
                AppendVariable(name + "[weight]", value.weight, false, ref body);
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, CustomsInfo value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[customs_certify]", value.customs_certify, false, ref body);
                    AppendVariable(name + "[customs_signer]", value.customs_signer, false, ref body);
                    AppendVariable(name + "[contents_type]", value.contents_type, false, ref body);
                    AppendVariable(name + "[contents_explanation]", value.contents_explanation, false, ref body);
                    AppendVariable(name + "[restriction_type]", value.restriction_type, false, ref body);
                    AppendVariable(name + "[restriction_comments]", value.restriction_comments, false, ref body);
                    AppendVariable(name + "[eel_pfc]", value.eel_pfc, false, ref body);
                    if (value.customs_items != null && value.customs_items.Length > 0)
                    {
                        for (var i = 0; i < value.customs_items.Length; i++)
                        {
                            AppendVariable(name + "[customs_items][" + i + "]", value.customs_items[i], false, ref body);
                        }
                    }
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, Shipment value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[batch_id]", value.batch_id, false, ref body);
                    AppendVariable(name + "[batch_status]", value.batch_status, false, ref body);
                    AppendVariable(name + "[buyer_address]", value.buyer_address, false, ref body);
                    AppendVariable(name + "[customs_info]", value.customs_info, false, ref body);

                    if (value.fees != null && value.fees.Length > 0)
                    {
                        for (var i = 0; i < value.fees.Length; i++)
                        {
                            AppendVariable(name + "[fees][" + i + "]", value.fees[i], false, ref body);
                        }
                    }

                    if (value.forms != null && value.forms.Length > 0)
                    {
                        for (var i = 0; i < value.forms.Length; i++)
                        {
                            AppendVariable(name + "[forms][" + i + "]", value.forms[i], false, ref body);
                        }
                    }

                    AppendVariable(name + "[from_address]", value.from_address, false, ref body);

                    AppendVariable(name + "[insurance]", value.insurance, false, ref body);
                    AppendVariable(name + "[is_return]", value.is_return, false, ref body);
                    AppendVariable(name + "[options]", value.options, false, ref body);
                    AppendVariable(name + "[parcel]", value.parcel, false, ref body);
                    AppendVariable(name + "[postage_label]", value.postage_label, false, ref body);
                    if (value.rates != null && value.rates.Length > 0)
                    {
                        for (var i = 0; i < value.rates.Length; i++)
                        {
                            AppendVariable(name + "[rates][" + i + "]", value.rates[i], false, ref body);
                        }
                    }
                    AppendVariable(name + "[reference]", value.reference, false, ref body);
                    AppendVariable(name + "[refund_status]", value.refund_status, false, ref body);
                    AppendVariable(name + "[return_address]", value.return_address, false, ref body);
                    AppendVariable(name + "[scan_form]", value.scan_form, false, ref body);
                    AppendVariable(name + "[selected_rate]", value.selected_rate, false, ref body);
                    AppendVariable(name + "[status]", value.status, false, ref body);
                    AppendVariable(name + "[to_address]", value.to_address, false, ref body);
                    AppendVariable(name + "[tracker]", value.tracker, false, ref body);
                    AppendVariable(name + "[tracking_code]", value.tracking_code, false, ref body);
                    AppendVariable(name + "[usps_zone]", value.usps_zone, false, ref body);
                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, CustomsItem value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.id))
                {
                    AppendVariable(name + "[description]", value.description, false, ref body);
                    AppendVariable(name + "[quantity]", value.quantity, false, ref body);
                    AppendVariable(name + "[value]", value.value, false, ref body);
                    AppendVariable(name + "[weight]", value.weight, false, ref body);
                    AppendVariable(name + "[hs_tariff_number]", value.hs_tariff_number, false, ref body);
                    AppendVariable(name + "[origin_country]", value.origin_country, false, ref body);
                    AppendVariable(name + "[code]", value.code, false, ref body);
                    AppendVariable(name + "[currency]", value.currency, false, ref body);

                }
                else
                {
                    AppendVariable(name + "[id]", value.id, false, ref body);
                }
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, string value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (!string.IsNullOrWhiteSpace(value))
            {
                body = name + "=" + System.Web.HttpUtility.UrlEncode(value);
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, float? value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null && value.HasValue)
            {
                body = name + "=" + value.Value.ToString();
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, double? value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null && value.HasValue)
            {
                body = name + "=" + value.Value.ToString();
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, DateTime? value, bool alwaysinclude, ref string output, bool dateonly = false)
        {
            string body = null;
            if (value != null && value.HasValue)
            {
                if (!dateonly)
                    body = name + "=" + value.Value.ToString();
                else
                    body = name + "=" + value.Value.ToString("yyyy-MM-ddTHH:mm:00Z");
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }
        protected void AppendVariable(string name, bool? value, bool alwaysinclude, ref string output)
        {
            string body = null;
            if (value != null && value.HasValue)
            {
                body = name + "=" + (value.Value ? "true" : "false");
            }
            else if (alwaysinclude)
            {
                body = name + "=";
            }
            if (body != null)
            {
                if (output != null && output.Length > 0) output += "&";
                output += body;
            }
        }

        protected StringContent GetBody(string data)
        {
            return this.GetBody(data, "application/x-www-form-urlencoded");
        }
        protected StringContent GetBody(string data, string mediatype)
        {
            var content = new StringContent(data);
            content.Headers.ContentType.MediaType = mediatype;
            return content;
        }
        #endregion
    }
}
