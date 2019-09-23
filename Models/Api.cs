using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Healthcheck.Models
{
    public class Api
    {
        public int Id { get; set; }
        public string  ApiName { get; set; }
        public int  ResponseStatus { get; set; }
        public string Method { get; set; }
    }
}
