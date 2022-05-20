using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Sample.EthereumTest.FunctionCaller.ContractDefinition
{


    public partial class FunctionCallerDeployment : FunctionCallerDeploymentBase
    {
        public FunctionCallerDeployment() : base(BYTECODE) { }
        public FunctionCallerDeployment(string byteCode) : base(byteCode) { }
    }

    public class FunctionCallerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public FunctionCallerDeploymentBase() : base(BYTECODE) { }
        public FunctionCallerDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CallNameFunction : CallNameFunctionBase { }

    [Function("callName", "string")]
    public class CallNameFunctionBase : FunctionMessage
    {
        [Parameter("address", "a", 1)]
        public virtual string A { get; set; }
    }

    public partial class CallNameOutputDTO : CallNameOutputDTOBase { }

    [FunctionOutput]
    public class CallNameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
