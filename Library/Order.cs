namespace EasyPost.Light.Library
{
    public class Order : BaseDefinition
    {
        public string reference;
        public string mode;
        public Address to_address;
        public Address from_address;
        public Address return_address;
        public Address buyer_address;
        public Shipment[] shipments;
        public Rate[] rates;
        public Message[] messages;
        public bool? is_return;
    }
}
