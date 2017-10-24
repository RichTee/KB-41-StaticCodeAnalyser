using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Models
{
    class DiagnosticReport
    {
        [JsonProperty]
        private string Message { get; set; }
        [JsonProperty]
        private string Severity { get; set; }
        [JsonProperty]
        private string Id { get; set; }
        [JsonProperty]
        private string Additional { get; set; }

        public DiagnosticReport(string Message, string Severity, string Id)
        {
            this.Message = Message;
            this.Severity = Severity;
            this.Id = Id;
        }

        public DiagnosticReport(string Message, string Severity, string Id, string Additional)
        {
            this.Message = Message;
            this.Severity = Severity;
            this.Id = Id;
            this.Additional = Additional;
        }
    }
}
