using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherscanApi.Net.Objects
{
    public class EtherScanDefaultResponse<T>
    {
        [JsonIgnore]
        public bool Success => Status == "1"&&Message=="OK";
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
