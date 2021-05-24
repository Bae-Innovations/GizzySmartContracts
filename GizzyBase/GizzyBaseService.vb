Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts.ContractHandlers
Imports Nethereum.Contracts
Imports System.Threading
Imports GizzySmartcontracts.Contracts.GizzyBase.ContractDefinition
Namespace GizzySmartcontracts.Contracts.GizzyBase


    Public Partial Class GizzyBaseService
    
    
        Public Shared Function DeployContractAndWaitForReceiptAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal gizzyBaseDeployment As GizzyBaseDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return web3.Eth.GetContractDeploymentHandler(Of GizzyBaseDeployment)().SendRequestAndWaitForReceiptAsync(gizzyBaseDeployment, cancellationTokenSource)
        
        End Function
         Public Shared Function DeployContractAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal gizzyBaseDeployment As GizzyBaseDeployment) As Task(Of String)
        
            Return web3.Eth.GetContractDeploymentHandler(Of GizzyBaseDeployment)().SendRequestAsync(gizzyBaseDeployment)
        
        End Function
        Public Shared Async Function DeployContractAndGetServiceAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal gizzyBaseDeployment As GizzyBaseDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of GizzyBaseService)
        
            Dim receipt = Await DeployContractAndWaitForReceiptAsync(web3, gizzyBaseDeployment, cancellationTokenSource)
            Return New GizzyBaseService(web3, receipt.ContractAddress)
        
        End Function
    
        Protected Property Web3 As Nethereum.Web3.Web3
        
        Public Property ContractHandler As ContractHandler
        
        Public Sub New(ByVal web3 As Nethereum.Web3.Web3, ByVal contractAddress As String)
            Web3 = web3
            ContractHandler = web3.Eth.GetContractHandler(contractAddress)
        End Sub
    
        Public Function ApproveRequestAsync(ByVal approveFunction As ApproveFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of ApproveFunction)(approveFunction)
        
        End Function

        Public Function ApproveRequestAndWaitForReceiptAsync(ByVal approveFunction As ApproveFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of ApproveFunction)(approveFunction, cancellationToken)
        
        End Function

        
        Public Function ApproveRequestAsync(ByVal [to] As String, ByVal [tokenId] As BigInteger) As Task(Of String)
        
            Dim approveFunction = New ApproveFunction()
                approveFunction.To = [to]
                approveFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAsync(Of ApproveFunction)(approveFunction)
        
        End Function

        
        Public Function ApproveRequestAndWaitForReceiptAsync(ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim approveFunction = New ApproveFunction()
                approveFunction.To = [to]
                approveFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of ApproveFunction)(approveFunction, cancellationToken)
        
        End Function
        Public Function BalanceOfQueryAsync(ByVal balanceOfFunction As BalanceOfFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Return ContractHandler.QueryAsync(Of BalanceOfFunction, BigInteger)(balanceOfFunction, blockParameter)
        
        End Function

        
        Public Function BalanceOfQueryAsync(ByVal [owner] As String, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Dim balanceOfFunction = New BalanceOfFunction()
                balanceOfFunction.Owner = [owner]
            
            Return ContractHandler.QueryAsync(Of BalanceOfFunction, BigInteger)(balanceOfFunction, blockParameter)
        
        End Function


        Public Function CeoAddressQueryAsync(ByVal ceoAddressFunction As CeoAddressFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of CeoAddressFunction, String)(ceoAddressFunction, blockParameter)
        
        End Function

        
        Public Function CeoAddressQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of CeoAddressFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function CfoAddressQueryAsync(ByVal cfoAddressFunction As CfoAddressFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of CfoAddressFunction, String)(cfoAddressFunction, blockParameter)
        
        End Function

        
        Public Function CfoAddressQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of CfoAddressFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function CooAddressQueryAsync(ByVal cooAddressFunction As CooAddressFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of CooAddressFunction, String)(cooAddressFunction, blockParameter)
        
        End Function

        
        Public Function CooAddressQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of CooAddressFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function CooldownsQueryAsync(ByVal cooldownsFunction As CooldownsFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of UInteger)
        
            Return ContractHandler.QueryAsync(Of CooldownsFunction, UInteger)(cooldownsFunction, blockParameter)
        
        End Function

        
        Public Function CooldownsQueryAsync(ByVal [returnValue1] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of UInteger)
        
            Dim cooldownsFunction = New CooldownsFunction()
                cooldownsFunction.ReturnValue1 = [returnValue1]
            
            Return ContractHandler.QueryAsync(Of CooldownsFunction, UInteger)(cooldownsFunction, blockParameter)
        
        End Function


        Public Function GetApprovedQueryAsync(ByVal getApprovedFunction As GetApprovedFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of GetApprovedFunction, String)(getApprovedFunction, blockParameter)
        
        End Function

        
        Public Function GetApprovedQueryAsync(ByVal [tokenId] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim getApprovedFunction = New GetApprovedFunction()
                getApprovedFunction.TokenId = [tokenId]
            
            Return ContractHandler.QueryAsync(Of GetApprovedFunction, String)(getApprovedFunction, blockParameter)
        
        End Function


        Public Function GizzyIndexToApprovedQueryAsync(ByVal gizzyIndexToApprovedFunction As GizzyIndexToApprovedFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of GizzyIndexToApprovedFunction, String)(gizzyIndexToApprovedFunction, blockParameter)
        
        End Function

        
        Public Function GizzyIndexToApprovedQueryAsync(ByVal [returnValue1] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim gizzyIndexToApprovedFunction = New GizzyIndexToApprovedFunction()
                gizzyIndexToApprovedFunction.ReturnValue1 = [returnValue1]
            
            Return ContractHandler.QueryAsync(Of GizzyIndexToApprovedFunction, String)(gizzyIndexToApprovedFunction, blockParameter)
        
        End Function


        Public Function GizzyIndexToOwnerQueryAsync(ByVal gizzyIndexToOwnerFunction As GizzyIndexToOwnerFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of GizzyIndexToOwnerFunction, String)(gizzyIndexToOwnerFunction, blockParameter)
        
        End Function

        
        Public Function GizzyIndexToOwnerQueryAsync(ByVal [returnValue1] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim gizzyIndexToOwnerFunction = New GizzyIndexToOwnerFunction()
                gizzyIndexToOwnerFunction.ReturnValue1 = [returnValue1]
            
            Return ContractHandler.QueryAsync(Of GizzyIndexToOwnerFunction, String)(gizzyIndexToOwnerFunction, blockParameter)
        
        End Function


        Public Function IsApprovedForAllQueryAsync(ByVal isApprovedForAllFunction As IsApprovedForAllFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Return ContractHandler.QueryAsync(Of IsApprovedForAllFunction, Boolean)(isApprovedForAllFunction, blockParameter)
        
        End Function

        
        Public Function IsApprovedForAllQueryAsync(ByVal [owner] As String, ByVal [operator] As String, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Dim isApprovedForAllFunction = New IsApprovedForAllFunction()
                isApprovedForAllFunction.Owner = [owner]
                isApprovedForAllFunction.Operator = [operator]
            
            Return ContractHandler.QueryAsync(Of IsApprovedForAllFunction, Boolean)(isApprovedForAllFunction, blockParameter)
        
        End Function


        Public Function NameQueryAsync(ByVal nameFunction As NameFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of NameFunction, String)(nameFunction, blockParameter)
        
        End Function

        
        Public Function NameQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of NameFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function OwnerOfQueryAsync(ByVal ownerOfFunction As OwnerOfFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of OwnerOfFunction, String)(ownerOfFunction, blockParameter)
        
        End Function

        
        Public Function OwnerOfQueryAsync(ByVal [tokenId] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim ownerOfFunction = New OwnerOfFunction()
                ownerOfFunction.TokenId = [tokenId]
            
            Return ContractHandler.QueryAsync(Of OwnerOfFunction, String)(ownerOfFunction, blockParameter)
        
        End Function


        Public Function PauseRequestAsync(ByVal pauseFunction As PauseFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of PauseFunction)(pauseFunction)
        
        End Function

        Public Function PauseRequestAsync() As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of PauseFunction)
        
        End Function

        Public Function PauseRequestAndWaitForReceiptAsync(ByVal pauseFunction As PauseFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of PauseFunction)(pauseFunction, cancellationToken)
        
        End Function

        Public Function PauseRequestAndWaitForReceiptAsync(ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of PauseFunction)(Nothing, cancellationToken)
        
        End Function
        Public Function PausedQueryAsync(ByVal pausedFunction As PausedFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Return ContractHandler.QueryAsync(Of PausedFunction, Boolean)(pausedFunction, blockParameter)
        
        End Function

        
        Public Function PausedQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            return ContractHandler.QueryAsync(Of PausedFunction, Boolean)(Nothing, blockParameter)
        
        End Function



        Public Function SafeTransferFromRequestAsync(ByVal safeTransferFromFunction As SafeTransferFromFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SafeTransferFromFunction)(safeTransferFromFunction)
        
        End Function

        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal safeTransferFromFunction As SafeTransferFromFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFromFunction)(safeTransferFromFunction, cancellationToken)
        
        End Function

        
        Public Function SafeTransferFromRequestAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger) As Task(Of String)
        
            Dim safeTransferFromFunction = New SafeTransferFromFunction()
                safeTransferFromFunction.From = [from]
                safeTransferFromFunction.To = [to]
                safeTransferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAsync(Of SafeTransferFromFunction)(safeTransferFromFunction)
        
        End Function

        
        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim safeTransferFromFunction = New SafeTransferFromFunction()
                safeTransferFromFunction.From = [from]
                safeTransferFromFunction.To = [to]
                safeTransferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFromFunction)(safeTransferFromFunction, cancellationToken)
        
        End Function
        Public Function SafeTransferFromRequestAsync(ByVal safeTransferFromFunction As SafeTransferFromFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SafeTransferFromFunction)(safeTransferFromFunction)
        
        End Function

        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal safeTransferFromFunction As SafeTransferFromFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFromFunction)(safeTransferFromFunction, cancellationToken)
        
        End Function

        
        Public Function SafeTransferFromRequestAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal [data] As Byte()) As Task(Of String)
        
            Dim safeTransferFromFunction = New SafeTransferFromFunction()
                safeTransferFromFunction.From = [from]
                safeTransferFromFunction.To = [to]
                safeTransferFromFunction.TokenId = [tokenId]
                safeTransferFromFunction.Data = [data]
            
            Return ContractHandler.SendRequestAsync(Of SafeTransferFromFunction)(safeTransferFromFunction)
        
        End Function

        
        Public Function SafeTransferFromRequestAndWaitForReceiptAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal [data] As Byte(), ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim safeTransferFromFunction = New SafeTransferFromFunction()
                safeTransferFromFunction.From = [from]
                safeTransferFromFunction.To = [to]
                safeTransferFromFunction.TokenId = [tokenId]
                safeTransferFromFunction.Data = [data]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SafeTransferFromFunction)(safeTransferFromFunction, cancellationToken)
        
        End Function
        Public Function SetApprovalForAllRequestAsync(ByVal setApprovalForAllFunction As SetApprovalForAllFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction)
        
        End Function

        Public Function SetApprovalForAllRequestAndWaitForReceiptAsync(ByVal setApprovalForAllFunction As SetApprovalForAllFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction, cancellationToken)
        
        End Function

        
        Public Function SetApprovalForAllRequestAsync(ByVal [operator] As String, ByVal [approved] As Boolean) As Task(Of String)
        
            Dim setApprovalForAllFunction = New SetApprovalForAllFunction()
                setApprovalForAllFunction.Operator = [operator]
                setApprovalForAllFunction.Approved = [approved]
            
            Return ContractHandler.SendRequestAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction)
        
        End Function

        
        Public Function SetApprovalForAllRequestAndWaitForReceiptAsync(ByVal [operator] As String, ByVal [approved] As Boolean, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim setApprovalForAllFunction = New SetApprovalForAllFunction()
                setApprovalForAllFunction.Operator = [operator]
                setApprovalForAllFunction.Approved = [approved]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetApprovalForAllFunction)(setApprovalForAllFunction, cancellationToken)
        
        End Function
        Public Function SetCEORequestAsync(ByVal setCEOFunction As SetCEOFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SetCEOFunction)(setCEOFunction)
        
        End Function

        Public Function SetCEORequestAndWaitForReceiptAsync(ByVal setCEOFunction As SetCEOFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetCEOFunction)(setCEOFunction, cancellationToken)
        
        End Function

        
        Public Function SetCEORequestAsync(ByVal [newCEO] As String) As Task(Of String)
        
            Dim setCEOFunction = New SetCEOFunction()
                setCEOFunction.NewCEO = [newCEO]
            
            Return ContractHandler.SendRequestAsync(Of SetCEOFunction)(setCEOFunction)
        
        End Function

        
        Public Function SetCEORequestAndWaitForReceiptAsync(ByVal [newCEO] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim setCEOFunction = New SetCEOFunction()
                setCEOFunction.NewCEO = [newCEO]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetCEOFunction)(setCEOFunction, cancellationToken)
        
        End Function
        Public Function SetCFORequestAsync(ByVal setCFOFunction As SetCFOFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SetCFOFunction)(setCFOFunction)
        
        End Function

        Public Function SetCFORequestAndWaitForReceiptAsync(ByVal setCFOFunction As SetCFOFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetCFOFunction)(setCFOFunction, cancellationToken)
        
        End Function

        
        Public Function SetCFORequestAsync(ByVal [newCFO] As String) As Task(Of String)
        
            Dim setCFOFunction = New SetCFOFunction()
                setCFOFunction.NewCFO = [newCFO]
            
            Return ContractHandler.SendRequestAsync(Of SetCFOFunction)(setCFOFunction)
        
        End Function

        
        Public Function SetCFORequestAndWaitForReceiptAsync(ByVal [newCFO] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim setCFOFunction = New SetCFOFunction()
                setCFOFunction.NewCFO = [newCFO]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetCFOFunction)(setCFOFunction, cancellationToken)
        
        End Function
        Public Function SetCOORequestAsync(ByVal setCOOFunction As SetCOOFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SetCOOFunction)(setCOOFunction)
        
        End Function

        Public Function SetCOORequestAndWaitForReceiptAsync(ByVal setCOOFunction As SetCOOFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetCOOFunction)(setCOOFunction, cancellationToken)
        
        End Function

        
        Public Function SetCOORequestAsync(ByVal [newCOO] As String) As Task(Of String)
        
            Dim setCOOFunction = New SetCOOFunction()
                setCOOFunction.NewCOO = [newCOO]
            
            Return ContractHandler.SendRequestAsync(Of SetCOOFunction)(setCOOFunction)
        
        End Function

        
        Public Function SetCOORequestAndWaitForReceiptAsync(ByVal [newCOO] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim setCOOFunction = New SetCOOFunction()
                setCOOFunction.NewCOO = [newCOO]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetCOOFunction)(setCOOFunction, cancellationToken)
        
        End Function
        Public Function SireAllowedToAddressQueryAsync(ByVal sireAllowedToAddressFunction As SireAllowedToAddressFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of SireAllowedToAddressFunction, String)(sireAllowedToAddressFunction, blockParameter)
        
        End Function

        
        Public Function SireAllowedToAddressQueryAsync(ByVal [returnValue1] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim sireAllowedToAddressFunction = New SireAllowedToAddressFunction()
                sireAllowedToAddressFunction.ReturnValue1 = [returnValue1]
            
            Return ContractHandler.QueryAsync(Of SireAllowedToAddressFunction, String)(sireAllowedToAddressFunction, blockParameter)
        
        End Function


        Public Function SupportsInterfaceQueryAsync(ByVal supportsInterfaceFunction As SupportsInterfaceFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Return ContractHandler.QueryAsync(Of SupportsInterfaceFunction, Boolean)(supportsInterfaceFunction, blockParameter)
        
        End Function

        
        Public Function SupportsInterfaceQueryAsync(ByVal [interfaceId] As Byte(), ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of Boolean)
        
            Dim supportsInterfaceFunction = New SupportsInterfaceFunction()
                supportsInterfaceFunction.InterfaceId = [interfaceId]
            
            Return ContractHandler.QueryAsync(Of SupportsInterfaceFunction, Boolean)(supportsInterfaceFunction, blockParameter)
        
        End Function


        Public Function SymbolQueryAsync(ByVal symbolFunction As SymbolFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of SymbolFunction, String)(symbolFunction, blockParameter)
        
        End Function

        
        Public Function SymbolQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of SymbolFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function TokenURIQueryAsync(ByVal tokenURIFunction As TokenURIFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of TokenURIFunction, String)(tokenURIFunction, blockParameter)
        
        End Function

        
        Public Function TokenURIQueryAsync(ByVal [tokenId] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Dim tokenURIFunction = New TokenURIFunction()
                tokenURIFunction.TokenId = [tokenId]
            
            Return ContractHandler.QueryAsync(Of TokenURIFunction, String)(tokenURIFunction, blockParameter)
        
        End Function


        Public Function TransferFromRequestAsync(ByVal transferFromFunction As TransferFromFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of TransferFromFunction)(transferFromFunction)
        
        End Function

        Public Function TransferFromRequestAndWaitForReceiptAsync(ByVal transferFromFunction As TransferFromFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of TransferFromFunction)(transferFromFunction, cancellationToken)
        
        End Function

        
        Public Function TransferFromRequestAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger) As Task(Of String)
        
            Dim transferFromFunction = New TransferFromFunction()
                transferFromFunction.From = [from]
                transferFromFunction.To = [to]
                transferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAsync(Of TransferFromFunction)(transferFromFunction)
        
        End Function

        
        Public Function TransferFromRequestAndWaitForReceiptAsync(ByVal [from] As String, ByVal [to] As String, ByVal [tokenId] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim transferFromFunction = New TransferFromFunction()
                transferFromFunction.From = [from]
                transferFromFunction.To = [to]
                transferFromFunction.TokenId = [tokenId]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of TransferFromFunction)(transferFromFunction, cancellationToken)
        
        End Function
        Public Function UnpauseRequestAsync(ByVal unpauseFunction As UnpauseFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of UnpauseFunction)(unpauseFunction)
        
        End Function

        Public Function UnpauseRequestAsync() As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of UnpauseFunction)
        
        End Function

        Public Function UnpauseRequestAndWaitForReceiptAsync(ByVal unpauseFunction As UnpauseFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of UnpauseFunction)(unpauseFunction, cancellationToken)
        
        End Function

        Public Function UnpauseRequestAndWaitForReceiptAsync(ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of UnpauseFunction)(Nothing, cancellationToken)
        
        End Function
        Public Function WithdrawBalanceRequestAsync(ByVal withdrawBalanceFunction As WithdrawBalanceFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of WithdrawBalanceFunction)(withdrawBalanceFunction)
        
        End Function

        Public Function WithdrawBalanceRequestAsync() As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of WithdrawBalanceFunction)
        
        End Function

        Public Function WithdrawBalanceRequestAndWaitForReceiptAsync(ByVal withdrawBalanceFunction As WithdrawBalanceFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of WithdrawBalanceFunction)(withdrawBalanceFunction, cancellationToken)
        
        End Function

        Public Function WithdrawBalanceRequestAndWaitForReceiptAsync(ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of WithdrawBalanceFunction)(Nothing, cancellationToken)
        
        End Function
    
    End Class

End Namespace
