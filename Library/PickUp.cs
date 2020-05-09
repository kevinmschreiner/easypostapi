using System;

namespace EasyPost.Light.Library
{
    public class PickUp : BaseDefinition
    {
        public string mode;
        public string reference;
        public string status;
        public DateTime? min_datetime;
        public DateTime? max_datetime;
        public bool? is_account_address;
        public string instructions;
        public Message[] messages;
        public string confirmation;
        public Shipment shipment;
        public Address address;
        public CarrierAccount[] carrier_accounts;
        public PickupRate[] pickup_rates;
    }
}
