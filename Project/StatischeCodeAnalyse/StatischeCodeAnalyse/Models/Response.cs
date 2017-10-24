using Newtonsoft.Json;
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
        [JsonProperty]
        private StatusCode StatusCode { get; set; }
        [JsonProperty]
        private string Message { get; set; }
        [JsonProperty]
        private string Additional { get; set; }

        public Response(StatusCode StatusCode, string Message, string Additional)
        {
            this.StatusCode = StatusCode;
            this.Message    = Message;
            this.Additional = Additional;
        }
    }
}
