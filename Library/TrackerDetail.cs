using System;

namespace EasyPost.Light.Library
{
    public class TrackingDetail
    {
        public string @object;
        public string message;
        public string status;
        public DateTime? datetime;
        public string source;
        public TrackingLocation tracking_location;
    }
}
