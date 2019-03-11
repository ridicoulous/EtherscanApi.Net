using EtherscanApi.Net.Converters;
using Newtonsoft.Json;

namespace EtherscanApi.Net.Objects
{
    public class BatchAddressBalance
    {
        [JsonProperty("account")]
        public string Address { get; set; }
        [JsonProperty("balance"), JsonConverter(typeof(FromGweiConverter))]
        public decimal Balance { get; set; }

    }
}
