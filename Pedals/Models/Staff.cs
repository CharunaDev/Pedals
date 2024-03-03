using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedals.Models
{
    public class Staff
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int active { get; set; }
        public int store_id { get; set; }
    }
}