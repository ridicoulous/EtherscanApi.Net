using EtherscanApi.Net.Interfaces;
using System;
using System.Linq;
using Xunit;

namespace EtherScanApi.Net.Tests
{
    public class EtherScanApiTests
    {
        EtherScanClient _client = new EtherScanClient("P2ZVEYIIEWSNDEUVHSTDC5Z7ZHC6IHVTWJ");
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
            var res = _client.GetTransactions("0x6fea7665684584884124c1867d7ec31b56c43383");
          //  Assert.True(res.Result.Any());
            Assert.True(res.Success);
        }
    }
}
