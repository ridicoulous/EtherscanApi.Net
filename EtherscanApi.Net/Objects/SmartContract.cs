using System;
using System.Collections.Generic;
using System.Text;

namespace EtherscanApi.Net.Objects
{
    public class SmartContract
    {
        public string SourceCode { get; set; }
        public string ABI { get; set; }
        public string ContractName { get; set; }
        public string CompilerVersion { get; set; }
        public string OptimizationUsed { get; set; }
        public string Runs { get; set; }
        public string ConstructorArguments { get; set; }
        public string Library { get; set; }
        public string SwarmSource { get; set; }
    }
}
