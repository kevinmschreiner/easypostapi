using System;

namespace EasyPost.Light.Library
{
    public class Tracker : BaseDefinition
    {
        public string mode;
        public string tracking_code;
        public string status;
        public string signed_by;
        public float? weight;
        public DateTime? est_delivery_date;
        public string shipment_id;
        public string carrier;
        public TrackingDetail[] tracking_details;
        public CarrierDetail carrier_detail;
        public string public_url;
        public Fee[] fees;
    }
}
