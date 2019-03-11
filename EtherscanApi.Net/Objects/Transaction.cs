using EtherscanApi.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherscanApi.Net.Objects
{
    public class Transaction
    {
        [JsonProperty("blockNumber"),JsonConverter(typeof(UlongFromStringConverter))]
        public ulong BlockNumber { get; set; }
        [JsonProperty("timeStamp"), JsonConverter(typeof(TimestampConverter))]
        public DateTime TimeStamp { get; set; }
        [JsonProperty("hash")]
        public string TxId { get; set; }
        public string nonce { get; set; }
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }
        [JsonProperty("transactionIndex")]
        public int TxIndex { get; set; }
        [JsonProperty("from")]
        public string FromId { get; set; }
        [JsonProperty("to")]
        public string ToId { get; set; }
        [JsonProperty("value"), JsonConverter(typeof(FromGweiConverter))]
        public decimal Value { get; set; }
        public string gas { get; set; }
        public string gasPrice { get; set; }
        [JsonProperty("isError"),JsonConverter(typeof(StringToBoolConverter))]
        public bool IsError { get; set; }
        public string txreceipt_status { get; set; }
        public string input { get; set; }
        public string contractAddress { get; set; }
        public string cumulativeGasUsed { get; set; }
        public string gasUsed { get; set; }
        public string confirmations { get; set; }
    }
}
