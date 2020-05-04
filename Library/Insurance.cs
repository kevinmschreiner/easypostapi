namespace EasyPost.Light.Library
{
    public class Insurance : BaseDefinition
    {
        public string mode;
        public string reference;
        public string amount;
        public string provider;
        public string provider_id;
        public string shipment_id;
        public string tracking_code;
        public string status;
        public Tracker tracker;
        public Address to_address;
        public Address from_address;
        public Fee fee;
        public string[] messages;
    }
}
