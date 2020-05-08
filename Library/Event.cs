using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPost.Light.Library
{
    public class Event : BaseDefinition
    {
        public string mode;
        public string description;
        public object previous_attributes;
        public object result;
        public string status;
        public string[] pending_urls;
        public string[] completed_urls;
    }
}
