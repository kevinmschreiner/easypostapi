namespace EasyPost.Light.Library
{
    public class Error
    {
        public string code;
        public string message;
        public FieldError[] errors;
        public class FieldError
        {
            public string field;
            public string message;
        }
    }
}
