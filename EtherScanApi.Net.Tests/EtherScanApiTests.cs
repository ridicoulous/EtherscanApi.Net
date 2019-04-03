using EtherscanApi.Net.Interfaces;
using System.Linq;
using Xunit;

namespace EtherScanApi.Net.Tests
{
    public class EtherScanApiTests
    {
        EtherScanClient _client = new EtherScanClient("");
        [Fact]
        public void Should_Return_Contract_Info()
        {
            var res = _client.GetSmartContractDescription("0x82f4ded9cec9b5750fbff5c2185aee35afc16587");
            Assert.True(res.Success);
        }
        [Fact]
        public void Should_Return_Balance()
        {
            var res = _client.GetEtherBalance("0x6Fea7665684584884124C1867d7eC31B56C43373");
            Assert.True(res.Success);
        }
        [Fact]
        public void Should_Return_TxList()
        {
            int? page = 1;
            while (page.HasValue)
            {
                var request = _client.GetTransactions("0xe4C89B9Fcab29c5BEe3971b698cca4528f2644e2", 6220000, page: page.Value, limit: 10);
                if (request.Success && request.Result.Any())
                {
                    var result = request.Result.Select(
                    f => new
                    {
                        Amount = f.Value,
                        Coin = "ETH",
                        Exchange = "KUNA",
                        FromId = f.FromId,
                        Timestamp = f.TimeStamp,
                        ToId = f.ToId,
                        ContractAddress = f.contractAddress,
                        IsValid = !f.IsError,
                        BlockNumber = f.BlockNumber,
                        f.TxId
                    });

                    var t = request.Result.Max(c => c.TimeStamp);
                    System.Diagnostics.Trace.Write(t);
                    page++;
                }
                else
                {
                    page = null;
                }
            }

            Assert.True(1 == 1);
        }
    }
}
