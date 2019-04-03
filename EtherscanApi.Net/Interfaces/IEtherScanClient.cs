using EtherscanApi.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherscanApi.Net.Interfaces
{
    public interface IEtherScanClient
    {
        EtherScanDefaultResponse<decimal> GetEtherBalance(string address);
        EtherScanDefaultResponse<List<Transaction>> GetTransactions(string address, ulong? fromBlock = null, ulong? toBlock = null, string sort = "asc", int? page = null, int? limit = null);

        EtherScanDefaultResponse<List<BatchAddressBalance>> GetEtherBalances(List<string> address);

        EtherScanDefaultResponse<List<SmartContract>> GetSmartContractDescription(string address);


    }
}
