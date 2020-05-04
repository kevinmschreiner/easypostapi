namespace EasyPost.Light.Library
{

    public class Rate : BaseDefinition
    {
        public string mode;
        public string service;
        public string carrier;
        public string carrier_account_id;
        public string shipment_id;
        public string rate;
        public string currency;
        public string retail_rate;
        public string retail_currency;
        public string list_rate;
        public string list_currency;
        public int? delivery_days;
        public string delivery_date;
        public bool? delivery_date_guaranteed;
    }
}
