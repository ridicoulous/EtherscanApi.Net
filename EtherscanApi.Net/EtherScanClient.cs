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
            return GetResult<decimal>(parameters);
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

        public EtherScanDefaultResponse<List<Transaction>> GetTransactions(string address, ulong? fromBlock = null, ulong? toBlock = null, string sort = "asc")
        {
            var parameters = new Dictionary<string, object>()
            {
                {"module", "account" },
                {"action", "txlist" },
                {"address", address },
                {"startblock",fromBlock },
                {"endblock",toBlock },
                {"sort",sort }
            };
            return GetResult<List<Transaction>>(parameters);
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
            catch (System.Exception)
            {
                return new EtherScanDefaultResponse<T>() { Message = "Unable to deserialize response" };
            }
        }


    }
}
