using EtherscanApi.Net.Converters;
using Newtonsoft.Json;
using System;

namespace EtherscanApi.Net.Objects
{
    public class Erc20TokenTransfer
    {
        public Erc20TokenTransfer()
        {

        }
        [JsonProperty("blockNumber")]
        [JsonConverter(typeof(UlongFromStringConverter))]
        public ulong BlockNumber { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("hash")]
        public string TxId { get; set; }

        [JsonProperty("nonce")]
        //  [JsonConverter(typeof(ParseStringConverter))]
        public int Nonce { get; set; }

        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("tokenName")]
        public string TokenName { get; set; }

        [JsonProperty("tokenSymbol")]
        public string TokenSymbol { get; set; }

        [JsonProperty("tokenDecimal")]
        // [JsonConverter(typeof(ParseStringConverter))]
        public int TokenDecimal { get; set; }
        [JsonProperty("value")]
        [JsonConverter(typeof(FromGweiConverter))]
        private decimal value { get; set; }
              //  return 
        public decimal Value => value / (decimal)Math.Pow(10d, (double)(TokenDecimal - 18));
        //{
        //    get
        //    {
        //        return value / (decimal)Math.Pow(10d, (double)(TokenDecimal-18));
        //    }
        //    set
        //    {
        //        Value = value;
        //    }
        //}
        [JsonProperty("transactionIndex")]
        //    [JsonConverter(typeof(ParseStringConverter))]
        public int TransactionIndex { get; set; }

        [JsonProperty("gas")]
        [JsonConverter(typeof(FromGweiConverter))]
        public decimal Gas { get; set; }

        [JsonProperty("gasPrice")]
        [JsonConverter(typeof(FromGweiConverter))]
        public decimal GasPrice { get; set; }

        [JsonProperty("gasUsed")]
        [JsonConverter(typeof(FromGweiConverter))]
        public decimal GasUsed { get; set; }

        [JsonProperty("cumulativeGasUsed")]
        [JsonConverter(typeof(FromGweiConverter))]
        public decimal CumulativeGasUsed { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("confirmations")]
        //    [JsonConverter(typeof(ParseStringConverter))]
        public int Confirmations { get; set; }
    }
}
