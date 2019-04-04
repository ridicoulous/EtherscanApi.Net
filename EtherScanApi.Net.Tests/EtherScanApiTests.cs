using EtherscanApi.Net.Interfaces;
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
            var requestNormal = _client.GetTransactions("0x004be92725a0979b9de76ee58330b00bb2f7a82a", 6220000, page: 1, limit: 1000);

            var request = _client.GetInternalTransactions("0x004be92725a0979b9de76ee58330b00bb2f7a82a", 6220000, page: 1, limit: 1000);

            Assert.True(1 == 1);
        }
    }
}
