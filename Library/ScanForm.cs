namespace EasyPost.Light.Library
{
    public class ScanForm : BaseDefinition
    {
        public string status;
        public string message;
        public Address address;
        public string[] tracking_codes;
        public string form_url;
        public string form_file_type;
        public string batch_id;
    }
}
