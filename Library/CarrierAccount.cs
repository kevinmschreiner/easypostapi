using System;

namespace EasyPost.Light.Library
{
    public class CarrierAccount : BaseDefinition
    {
        public string @type;
        public Fields fields;
        public bool? clone;
        public string description;
        public string reference;
        public string readable;
        public object credentials;
        public object test_credentials;
    }
}
