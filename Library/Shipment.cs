namespace EasyPost.Light.Library
{
    public class Shipment : BaseDefinition
    {
        public string reference;
        public string mode;
        public Address to_address;
        public Address from_address;
        public Address return_address;
        public Address buyer_address;
        public Parcel parcel;
        public CustomsInfo customs_info;
        public ScanForm scan_form;
        public Form[] forms;
        public Insurance insurance;
        public Rate[] rates;
        public Rate selected_rate;
        public PostageLabel postage_label;
        public Message[] messages;
        public Options options;
        public bool? is_return;
        public string tracking_code;
        public string usps_zone;
        public string status;
        public Tracker tracker;
        public Fee[] fees;
        public string refund_status;
        public string batch_id;
        public string batch_status;
    }
}
