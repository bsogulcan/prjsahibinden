using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCollector.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Advertisement
    {
        [JsonProperty("id")]
        public int ID;

        [JsonProperty("aD_NO")]
        public string AD_NO;

        [JsonProperty("miN_PRCE")]
        public int MIN_PRCE;

        [JsonProperty("emaiL_ADRESS")]
        public string EMAIL_ADRESS;

        [JsonProperty("aD_TITLE")]
        public string AD_TITLE;

        [JsonProperty("aD_PICTURE")]
        public string AD_PICTURE;
    }
 


}
