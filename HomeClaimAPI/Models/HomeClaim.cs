using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeClaimAPI.Models
{
    public class HomeClaim
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "claimTitle")]
        public string claimTitle { get; set; }

        [JsonProperty(PropertyName = "insured")]
        public string insured { get; set; }

        [JsonProperty(PropertyName = "claimType")]
        public string claimType { get; set; }

        [JsonProperty(PropertyName = "claimAmount")]
        public string claimAmount { get; set; }

        [JsonProperty(PropertyName = "claimReasons")]
        public string claimReasons { get; set; }

        [JsonProperty(PropertyName = "locationAddress")]
        public string locationAddress { get; set; }

        [JsonProperty(PropertyName = "lossDatePicker")]
        public DateTime? lossDatePicker { get; set; }

        [JsonProperty(PropertyName = "claimDatePicker")]
        public DateTime? claimDatePicker { get; set; }

        [JsonProperty(PropertyName = "producer")]
        public string producer { get; set; }

        [JsonProperty(PropertyName = "policyNumber")]
        public string policyNumber { get; set; }

        [JsonProperty(PropertyName = "file")]
        public string file { get; set; }



        //"id": "HC01",
        //"claimTitle":"Test Claim",
        //"insured":"Test Test",
        //"claimType": "ISO",
        //"claimAmount":"5000",
        //"claimReasons":"Fire/ Lightenting",
        //"locationAddress": "TX",
        //"lossDatePicker":"02/15/2019",
        //"claimDatePicker":"02/27/2019",
        //"producer":"Murray"
    }
}
