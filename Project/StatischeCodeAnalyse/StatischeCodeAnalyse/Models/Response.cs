using StatischeCodeAnalyse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Models
{
    class Response
    {
        public StatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string Additional { get; set; }

        public Response(StatusCode StatusCode, string Message, string Additional)
        {
            this.StatusCode = StatusCode;
            this.Message    = Message;
            this.Additional = Additional;
        }
    }
}
