namespace EasyPost.Light.Library
{
    public class CustomsInfo : BaseDefinition
    {
        public string eel_pfc;
        public string contents_type;
        public string contents_explanation;
        public bool? customs_certify;
        public string customs_signer;
        public string non_delivery_option;
        public string restriction_type;
        public string restriction_comments;
        public CustomsItem[] customs_items;
    }
}
