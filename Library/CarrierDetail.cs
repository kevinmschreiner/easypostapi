using System;
namespace EasyPost.Light.Library
{
    public class CarrierDetail
    {
        public string @object;
        public string service;
        public string container_type;
        public DateTime? est_delivery_date_local;
        public DateTime? est_delivery_time_local;
        public string origin_location;
        public TrackingLocation origin_tracking_location;
        public string destination_location;
        public TrackingLocation destination_tracking_location;
        public DateTime? guaranteed_delivery_date;
        public string alternate_identifier;
        public DateTime? initial_delivery_attempt;
    }
}
