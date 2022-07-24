using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace helloWorld.ItemStorage.ContractDefinition
{
    public partial class Offer : OfferBase { }

    public class OfferBase 
    {
        [Parameter("address", "buyer", 1)]
        public virtual string Buyer { get; set; }
        [Parameter("address", "seller", 2)]
        public virtual string Seller { get; set; }
        [Parameter("uint256", "itemId", 3)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "amount", 4)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("uint256", "gold", 5)]
        public virtual BigInteger Gold { get; set; }
    }
}
