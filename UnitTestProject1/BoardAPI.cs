using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    public class BoardAPI
    {
        [JsonProperty(PropertyName = "activity")]
       
        public string Activity { get; set; }

        [JsonProperty(PropertyName ="type")]

        public  string Type { get; set; }

        [JsonProperty(PropertyName = "participants")]

        public string Participants { get; set; }

    }
}
