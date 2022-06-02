using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace helloWorld.ItemStorage.ContractDefinition
{
    public partial class Item : ItemBase { }

    public class ItemBase 
    {
        [Parameter("uint256", "idType", 1)]
        public virtual BigInteger IdType { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 3)]
        public virtual string Description { get; set; }
        [Parameter("uint256", "damage", 4)]
        public virtual BigInteger Damage { get; set; }
        [Parameter("string", "cid", 5)]
        public virtual string Cid { get; set; }
    }
}
