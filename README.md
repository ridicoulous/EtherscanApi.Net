# EtherscanApi.Net
Simple C# wrapper to interact with eherscan api

# Usage:
You need to instatiate EtherScanClient using your api key from  [EtherScan](https://etherscan.io):
```cs
EtherScanClient etherScanClient = new EtherScanClient("_apiKey");
var balance = etherScanClient.GetEtherBalance("0x6Fea7665684584884124C1867d7eC31B56C43373");

```


## Installation
![Nuget version](https://img.shields.io/nuget/v/EtherscanApi.Net.svg) ![Nuget downloads](https://img.shields.io/nuget/dt/EtherscanApi.Net.svg)

Available on [NuGet](https://www.nuget.org/packages/EtherscanApi.Net/):
```
PM> Install-Package EtherscanApi.Net
```
