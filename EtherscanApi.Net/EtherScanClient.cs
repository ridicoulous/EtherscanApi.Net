﻿using EtherscanApi.Net.Converters;
using EtherscanApi.Net.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EtherscanApi.Net.Interfaces
{
    public class EtherScanClient : IEtherScanClient
    {
        private const string _baseUrl = "https://api.etherscan.io/api?";
        private readonly string _apiKey;
        WebClient wc = new WebClient();
        public EtherScanClient(string apiKey)
        {
            _apiKey = apiKey;
        }
        public EtherScanDefaultResponse<decimal> GetEtherBalance(string address)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"module", "account" },
                {"action", "balance" },
                {"address", address }
            };
            var result = GetResult<decimal>(parameters);
            if (result.Success)
                result.Result = UnitConversion.Convert.FromWei(new System.Numerics.BigInteger(result.Result), UnitConversion.EthUnit.Ether);
            return result;
        }

        public EtherScanDefaultResponse<List<BatchAddressBalance>> GetEtherBalances(List<string> address)
        {
            throw new System.NotImplementedException();
        }

        public EtherScanDefaultResponse<List<SmartContract>> GetSmartContractDescription(string address)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"module", "contract" },
                {"action", "getsourcecode" },
                {"address", address }
            };
            return GetResult<List<SmartContract>>(parameters);
        }

        public EtherScanDefaultResponse<List<Transaction>> GetTransactions(string address, ulong? fromBlock = null, ulong? toBlock = null, string sort = "asc", int? page = 1, int? limit = 1000)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"module", "account" },
                {"action", "txlist" },
                {"address", address },
                {"startblock",fromBlock },
                {"endblock",toBlock??99999999 },
                {"sort",sort },
                {"page",page },
                {"offset",limit }

            };
            return GetResult<List<Transaction>>(parameters);
        }
        public EtherScanDefaultResponse<List<Transaction>> GetInternalTransactions(string address, ulong? fromBlock = null, ulong? toBlock = null, string sort = "asc", int? page = 1, int? limit = 1000)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"module", "account" },
                {"action", "txlistinternal" },
                {"address", address },
                {"startblock",fromBlock },
                {"endblock",toBlock??99999999 },
                {"sort",sort },
                {"page",page },
                {"offset",limit }

            };
            return GetResult<List<Transaction>>(parameters);
        }

        public EtherScanDefaultResponse<List<Erc20TokenTransfer>> GetErc20TokenTransfers(string address, string contract = null, ulong? fromBlock = null, ulong? toBlock = null, string sort = "asc", int? page = 1, int? limit = 1000)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"module", "account" },
                {"action", "tokentx" },
                {"address", address },

                {"startblock",fromBlock },
                {"endblock",toBlock??99999999 },
                {"sort",sort },
                {"page",page },
                {"offset",limit }

            };
            if (!string.IsNullOrEmpty(contract))
            {
                parameters.Add("contractaddress", contract);
            }
            return GetResult<List<Erc20TokenTransfer>>(parameters);
        }

        private string ConstructRequest(Dictionary<string, object> parameters)
        {
            parameters.Add("apiKey", _apiKey);
            string requestUrl = _baseUrl + string.Join("&", parameters.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));
            return requestUrl;
        }

        private EtherScanDefaultResponse<T> GetResult<T>(Dictionary<string, object> parameters)
        {
            try
            {
                string httpApiResult = wc.DownloadString(ConstructRequest(parameters));
                return JsonConvert.DeserializeObject<EtherScanDefaultResponse<T>>(httpApiResult);
            }
            catch (System.Exception ex)
            {
                return new EtherScanDefaultResponse<T>() { Message = "Unable to deserialize response" };
            }
        }


    }
}
