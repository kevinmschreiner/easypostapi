namespace EasyPost.Light.Library
{
    public class Verifications
    {
        public Verification zip4;
        public Verification delivery;

        public class Verification
        {
            public bool success;
            public Error.FieldError[] errors;
            public VerificationDetails details;

            public class VerificationDetails
            {
                public string latitude;
                public string longitude;
                public string time_zone;
            }
        }
    }
}
