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
using Sample.EthereumTest.FunctionCaller.ContractDefinition;

namespace Sample.EthereumTest.FunctionCaller
{
    public partial class FunctionCallerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, FunctionCallerDeployment functionCallerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<FunctionCallerDeployment>().SendRequestAndWaitForReceiptAsync(functionCallerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, FunctionCallerDeployment functionCallerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<FunctionCallerDeployment>().SendRequestAsync(functionCallerDeployment);
        }

        public static async Task<FunctionCallerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, FunctionCallerDeployment functionCallerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, functionCallerDeployment, cancellationTokenSource);
            return new FunctionCallerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public FunctionCallerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CallNameQueryAsync(CallNameFunction callNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CallNameFunction, string>(callNameFunction, blockParameter);
        }

        
        public Task<string> CallNameQueryAsync(string a, BlockParameter blockParameter = null)
        {
            var callNameFunction = new CallNameFunction();
                callNameFunction.A = a;
            
            return ContractHandler.QueryAsync<CallNameFunction, string>(callNameFunction, blockParameter);
        }
    }
}
