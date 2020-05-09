namespace EasyPost.Light.Library
{
    public class Batch : BaseDefinition
    {
        public string mode;
        public string reference;
        public string state;
        public int? num_shipments;
        public BatchShipment[] shipments;
        public object status;
        public string label_url;
        public ScanForm scan_form;
        public PickUp pickup;
    }
}
