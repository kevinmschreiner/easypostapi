using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPost.Light.Library
{
    public class Report:BaseDefinition
    {
        public string mode;
        public string status;
        public string start_date;
        public string end_date;
        public bool? include_children;
        public string url;
        public DateTime? url_expires_at;
        public bool? send_email;
    }
}
