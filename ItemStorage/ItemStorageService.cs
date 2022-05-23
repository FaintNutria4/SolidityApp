using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using helloWorld.ItemStorage.ContractDefinition;

namespace helloWorld.ItemStorage
{
    public partial class ItemStorageService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ItemStorageDeployment itemStorageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ItemStorageDeployment>().SendRequestAndWaitForReceiptAsync(itemStorageDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ItemStorageDeployment itemStorageDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ItemStorageDeployment>().SendRequestAsync(itemStorageDeployment);
        }

        public static async Task<ItemStorageService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ItemStorageDeployment itemStorageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, itemStorageDeployment, cancellationTokenSource);
            return new ItemStorageService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ItemStorageService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreateItemRequestAsync(CreateItemFunction createItemFunction)
        {
             return ContractHandler.SendRequestAsync(createItemFunction);
        }

        public Task<TransactionReceipt> CreateItemRequestAndWaitForReceiptAsync(CreateItemFunction createItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createItemFunction, cancellationToken);
        }

        public Task<string> CreateItemRequestAsync(BigInteger idType, string name, string description, BigInteger damage, string owner)
        {
            var createItemFunction = new CreateItemFunction();
                createItemFunction.IdType = idType;
                createItemFunction.Name = name;
                createItemFunction.Description = description;
                createItemFunction.Damage = damage;
                createItemFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(createItemFunction);
        }

        public Task<TransactionReceipt> CreateItemRequestAndWaitForReceiptAsync(BigInteger idType, string name, string description, BigInteger damage, string owner, CancellationTokenSource cancellationToken = null)
        {
            var createItemFunction = new CreateItemFunction();
                createItemFunction.IdType = idType;
                createItemFunction.Name = name;
                createItemFunction.Description = description;
                createItemFunction.Damage = damage;
                createItemFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createItemFunction, cancellationToken);
        }

        public Task<List<BigInteger>> GetBalancesQueryAsync(GetBalancesFunction getBalancesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalancesFunction, List<BigInteger>>(getBalancesFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> GetBalancesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalancesFunction, List<BigInteger>>(null, blockParameter);
        }
    }
}
