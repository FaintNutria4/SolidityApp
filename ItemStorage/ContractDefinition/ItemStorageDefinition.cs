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

namespace helloWorld.ItemStorage.ContractDefinition
{


    public partial class ItemStorageDeployment : ItemStorageDeploymentBase
    {
        public ItemStorageDeployment() : base(BYTECODE) { }
        public ItemStorageDeployment(string byteCode) : base(byteCode) { }
    }

    public class ItemStorageDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public ItemStorageDeploymentBase() : base(BYTECODE) { }
        public ItemStorageDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CreateItemFunction : CreateItemFunctionBase { }

    [Function("createItem", typeof(CreateItemOutputDTO))]
    public class CreateItemFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_idType", 1)]
        public virtual BigInteger IdType { get; set; }
        [Parameter("string", "_name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 3)]
        public virtual string Description { get; set; }
        [Parameter("uint256", "damage", 4)]
        public virtual BigInteger Damage { get; set; }
        [Parameter("address", "_owner", 5)]
        public virtual string Owner { get; set; }
    }

    public partial class GetBalancesFunction : GetBalancesFunctionBase { }

    [Function("getBalances", "uint256[]")]
    public class GetBalancesFunctionBase : FunctionMessage
    {

    }

    public partial class CreateItemOutputDTO : CreateItemOutputDTOBase { }

    [FunctionOutput]
    public class CreateItemOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Item ReturnValue1 { get; set; }
    }

    public partial class GetBalancesOutputDTO : GetBalancesOutputDTOBase { }

    [FunctionOutput]
    public class GetBalancesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }
}
