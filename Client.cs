using System;
using System.Net.Http;
using EasyPost.Light.Library;

namespace EasyPost.Light
{
    public class Client
    {
        private Services.AddressService address_service;
        private Services.InsuranceService insurance_service;
        private Services.ParcelService parcel_service;
        private Services.PickupService pickup_service;
        private Services.ReportService report_service;
        private Services.ShipmentService shipment_service;
        private Services.TrackerService tracker_service;

        public Client(string key)
        {
            this.address_service = new Services.AddressService(key);
            this.insurance_service = new Services.InsuranceService(key);
            this.parcel_service = new Services.ParcelService(key);
            this.pickup_service = new Services.PickupService(key);
            this.report_service = new Services.ReportService(key);
            this.shipment_service = new Services.ShipmentService(key);
            this.tracker_service = new Services.TrackerService(key);
            
        }

        public Services.AddressService Addresses { get { return address_service; } }
        public Services.InsuranceService Insurance { get { return insurance_service; } }
        public Services.ParcelService Parcels { get { return parcel_service; } }
        public Services.PickupService Pickups { get { return pickup_service; } }
        public Services.ReportService Reports { get { return report_service; } }
        public Services.ShipmentService Shipments { get { return shipment_service; } }
        public Services.TrackerService Trackers { get { return tracker_service; } }
    }
}
