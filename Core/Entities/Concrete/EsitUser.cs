using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class EsitUser
    {
        public string UserName { get; set; }
        public string RequestDate { get; set; }
        public string EsitActionName { get; set; }
        public string Ip { get; set; }
        public string SecurityKey { get; set; }

    }
}
