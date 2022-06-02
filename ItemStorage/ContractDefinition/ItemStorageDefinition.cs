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
        [Parameter("uint256", "_damage", 4)]
        public virtual BigInteger Damage { get; set; }
        [Parameter("string", "_cid", 5)]
        public virtual string Cid { get; set; }
    }

    public partial class TransferItemToAddressFunction : TransferItemToAddressFunctionBase { }

    [Function("transferItemToAddress")]
    public class TransferItemToAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
        [Parameter("uint256", "_idType", 2)]
        public virtual BigInteger IdType { get; set; }
        [Parameter("uint256", "_amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class AddItemToAddressFunction : AddItemToAddressFunctionBase { }

    [Function("addItemToAddress")]
    public class AddItemToAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
        [Parameter("uint256", "_idType", 2)]
        public virtual BigInteger IdType { get; set; }
        [Parameter("uint256", "_items", 3)]
        public virtual BigInteger Items { get; set; }
    }

    public partial class GetBalancesFunction : GetBalancesFunctionBase { }

    [Function("getBalances", "uint256[]")]
    public class GetBalancesFunctionBase : FunctionMessage
    {

    }

    public partial class GetItemStatsFunction : GetItemStatsFunctionBase { }

    [Function("getItemStats", typeof(GetItemStatsOutputDTO))]
    public class GetItemStatsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_idType", 1)]
        public virtual BigInteger IdType { get; set; }
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

    public partial class GetItemStatsOutputDTO : GetItemStatsOutputDTOBase { }

    [FunctionOutput]
    public class GetItemStatsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Item ReturnValue1 { get; set; }
    }
}
