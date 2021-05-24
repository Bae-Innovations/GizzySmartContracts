Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts
Imports System.Threading
Namespace GizzySmartcontracts.Contracts.GizzyBase.ContractDefinition

    
    
    Public Partial Class GizzyBaseDeployment
     Inherits GizzyBaseDeploymentBase
    
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
    
    End Class

    Public Class GizzyBaseDeploymentBase 
            Inherits ContractDeploymentMessage
        
        Public Shared DEFAULT_BYTECODE As String = "6002805460ff60a01b19169055610240604052603c6080908152607860a05261012c60c05261025860e05261070861010052610e1061012052611c2061014052613840610160526170806101805261e1006101a052620151806101c0526202a3006101e052620546006102005262093a80610220526200008490600990600e62000104565b503480156200009257600080fd5b506040518060400160405280600581526020016447697a7a7960d81b81525060405180604001604052806003815260200162475a5960e81b8152508160039080519060200190620000e5929190620001a7565b508051620000fb906004906020840190620001a7565b50505062000278565b600283019183908215620001955791602002820160005b838211156200016157835183826101000a81548163ffffffff021916908363ffffffff16021790555092602001926004016020816003010492830192600103026200011b565b8015620001935782816101000a81549063ffffffff021916905560040160208160030104928301926001030262000161565b505b50620001a392915062000224565b5090565b828054620001b5906200023b565b90600052602060002090601f016020900481019282620001d9576000855562000195565b82601f10620001f457805160ff191683800117855562000195565b8280016001018555821562000195579182015b828111156200019557825182559160200191906001019062000207565b5b80821115620001a3576000815560010162000225565b600181811c908216806200025057607f821691505b602082108114156200027257634e487b7160e01b600052602260045260246000fd5b50919050565b61166780620002886000396000f3fe608060405234801561001057600080fd5b50600436106101a95760003560e01c806346116e6f116100f957806395d89b4111610097578063b047fb5011610071578063b047fb50146103ce578063b88d4fde146103e1578063c87b56dd146103f4578063e985e9c51461040757600080fd5b806395d89b411461038b5780639d6fac6f14610393578063a22cb465146103bb57600080fd5b80635fd8c710116100d35780635fd8c710146103475780636352211e1461034f57806370a08231146103625780638456cb591461038357600080fd5b806346116e6f146102f75780634e0a3379146103205780635c975abb1461033357600080fd5b806318eb540b1161016657806327d7874c1161014057806327d7874c146102b65780632ba73c15146102c95780633f4ba83a146102dc57806342842e0e146102e457600080fd5b806318eb540b1461025157806323668d981461027a57806323b872dd146102a357600080fd5b806301ffc9a7146101ae5780630519ce79146101d657806306fdde0314610201578063081812fc14610216578063095ea7b3146102295780630a0f81681461023e575b600080fd5b6101c16101bc36600461134d565b610443565b60405190151581526020015b60405180910390f35b6001546101e9906001600160a01b031681565b6040516001600160a01b0390911681526020016101cd565b610209610495565b6040516101cd9190611435565b6101e9610224366004611385565b610527565b61023c610237366004611322565b6105c1565b005b6000546101e9906001600160a01b031681565b6101e961025f366004611385565b600e602052600090815260409020546001600160a01b031681565b6101e9610288366004611385565b600c602052600090815260409020546001600160a01b031681565b61023c6102b13660046111d8565b6106d7565b61023c6102c4366004611184565b610708565b61023c6102d7366004611184565b610754565b61023c6107a0565b61023c6102f23660046111d8565b6107dc565b6101e9610305366004611385565b600f602052600090815260409020546001600160a01b031681565b61023c61032e366004611184565b6107f7565b6002546101c190600160a01b900460ff1681565b61023c610843565b6101e961035d366004611385565b610896565b610375610370366004611184565b61090d565b6040519081526020016101cd565b61023c610994565b610209610a01565b6103a66103a1366004611385565b610a10565b60405163ffffffff90911681526020016101cd565b61023c6103c93660046112f1565b610a40565b6002546101e9906001600160a01b031681565b61023c6103ef366004611218565b610b05565b610209610402366004611385565b610b3d565b6101c16104153660046111a0565b6001600160a01b03918216600090815260086020908152604080832093909416825291909152205460ff1690565b60006001600160e01b031982166380ac58cd60e01b148061047457506001600160e01b03198216635b5e139f60e01b145b8061048f57506301ffc9a760e01b6001600160e01b03198316145b92915050565b6060600380546104a49061155a565b80601f01602080910402602001604051908101604052809291908181526020018280546104d09061155a565b801561051d5780601f106104f25761010080835404028352916020019161051d565b820191906000526020600020905b81548152906001019060200180831161050057829003601f168201915b5050505050905090565b6000818152600560205260408120546001600160a01b03166105a55760405162461bcd60e51b815260206004820152602c60248201527f4552433732313a20617070726f76656420717565727920666f72206e6f6e657860448201526b34b9ba32b73a103a37b5b2b760a11b60648201526084015b60405180910390fd5b506000908152600760205260409020546001600160a01b031690565b60006105cc82610896565b9050806001600160a01b0316836001600160a01b0316141561063a5760405162461bcd60e51b815260206004820152602160248201527f4552433732313a20617070726f76616c20746f2063757272656e74206f776e656044820152603960f91b606482015260840161059c565b336001600160a01b038216148061065657506106568133610415565b6106c85760405162461bcd60e51b815260206004820152603860248201527f4552433732313a20617070726f76652063616c6c6572206973206e6f74206f7760448201527f6e6572206e6f7220617070726f76656420666f7220616c6c0000000000000000606482015260840161059c565b6106d28383610c25565b505050565b6106e13382610c93565b6106fd5760405162461bcd60e51b815260040161059c9061149a565b6106d2838383610d8a565b6000546001600160a01b0316331461071f57600080fd5b6001600160a01b03811661073257600080fd5b600080546001600160a01b0319166001600160a01b0392909216919091179055565b6000546001600160a01b0316331461076b57600080fd5b6001600160a01b03811661077e57600080fd5b600280546001600160a01b0319166001600160a01b0392909216919091179055565b6000546001600160a01b031633146107b757600080fd5b600254600160a01b900460ff166107cd57600080fd5b6002805460ff60a01b19169055565b6106d283838360405180602001604052806000815250610b05565b6000546001600160a01b0316331461080e57600080fd5b6001600160a01b03811661082157600080fd5b600180546001600160a01b0319166001600160a01b0392909216919091179055565b6001546001600160a01b0316331461085a57600080fd5b6001546040516001600160a01b03909116904780156108fc02916000818181858888f19350505050158015610893573d6000803e3d6000fd5b50565b6000818152600560205260408120546001600160a01b03168061048f5760405162461bcd60e51b815260206004820152602960248201527f4552433732313a206f776e657220717565727920666f72206e6f6e657869737460448201526832b73a103a37b5b2b760b91b606482015260840161059c565b60006001600160a01b0382166109785760405162461bcd60e51b815260206004820152602a60248201527f4552433732313a2062616c616e636520717565727920666f7220746865207a65604482015269726f206164647265737360b01b606482015260840161059c565b506001600160a01b031660009081526006602052604090205490565b6002546001600160a01b03163314806109b757506000546001600160a01b031633145b806109cc57506001546001600160a01b031633145b6109d557600080fd5b600254600160a01b900460ff16156109ec57600080fd5b6002805460ff60a01b1916600160a01b179055565b6060600480546104a49061155a565b600981600e8110610a2057600080fd5b60089182820401919006600402915054906101000a900463ffffffff1681565b6001600160a01b038216331415610a995760405162461bcd60e51b815260206004820152601960248201527f4552433732313a20617070726f766520746f2063616c6c657200000000000000604482015260640161059c565b3360008181526008602090815260408083206001600160a01b03871680855290835292819020805460ff191686151590811790915590519081529192917f17307eab39ab6107e8899845ad3d59bd9653f200f220920489ca2b5937696c31910160405180910390a35050565b610b0f3383610c93565b610b2b5760405162461bcd60e51b815260040161059c9061149a565b610b3784848484610f2a565b50505050565b6000818152600560205260409020546060906001600160a01b0316610bbc5760405162461bcd60e51b815260206004820152602f60248201527f4552433732314d657461646174613a2055524920717565727920666f72206e6f60448201526e3732bc34b9ba32b73a103a37b5b2b760891b606482015260840161059c565b6000610bd360408051602081019091526000815290565b90506000815111610bf35760405180602001604052806000815250610c1e565b80610bfd84610f5d565b604051602001610c0e9291906113c9565b6040516020818303038152906040525b9392505050565b600081815260076020526040902080546001600160a01b0319166001600160a01b0384169081179091558190610c5a82610896565b6001600160a01b03167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92560405160405180910390a45050565b6000818152600560205260408120546001600160a01b0316610d0c5760405162461bcd60e51b815260206004820152602c60248201527f4552433732313a206f70657261746f7220717565727920666f72206e6f6e657860448201526b34b9ba32b73a103a37b5b2b760a11b606482015260840161059c565b6000610d1783610896565b9050806001600160a01b0316846001600160a01b03161480610d525750836001600160a01b0316610d4784610527565b6001600160a01b0316145b80610d8257506001600160a01b0380821660009081526008602090815260408083209388168352929052205460ff165b949350505050565b826001600160a01b0316610d9d82610896565b6001600160a01b031614610e055760405162461bcd60e51b815260206004820152602960248201527f4552433732313a207472616e73666572206f6620746f6b656e2074686174206960448201526839903737ba1037bbb760b91b606482015260840161059c565b6001600160a01b038216610e675760405162461bcd60e51b8152602060048201526024808201527f4552433732313a207472616e7366657220746f20746865207a65726f206164646044820152637265737360e01b606482015260840161059c565b610e72600082610c25565b6001600160a01b0383166000908152600660205260408120805460019290610e9b908490611517565b90915550506001600160a01b0382166000908152600660205260408120805460019290610ec99084906114eb565b909155505060008181526005602052604080822080546001600160a01b0319166001600160a01b0386811691821790925591518493918716917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef91a4505050565b610f35848484610d8a565b610f4184848484611077565b610b375760405162461bcd60e51b815260040161059c90611448565b606081610f815750506040805180820190915260018152600360fc1b602082015290565b8160005b8115610fab5780610f9581611595565b9150610fa49050600a83611503565b9150610f85565b60008167ffffffffffffffff811115610fd457634e487b7160e01b600052604160045260246000fd5b6040519080825280601f01601f191660200182016040528015610ffe576020820181803683370190505b5090505b8415610d8257611013600183611517565b9150611020600a866115b0565b61102b9060306114eb565b60f81b81838151811061104e57634e487b7160e01b600052603260045260246000fd5b60200101906001600160f81b031916908160001a905350611070600a86611503565b9450611002565b60006001600160a01b0384163b1561117957604051630a85bd0160e11b81526001600160a01b0385169063150b7a02906110bb9033908990889088906004016113f8565b602060405180830381600087803b1580156110d557600080fd5b505af1925050508015611105575060408051601f3d908101601f1916820190925261110291810190611369565b60015b61115f573d808015611133576040519150601f19603f3d011682016040523d82523d6000602084013e611138565b606091505b5080516111575760405162461bcd60e51b815260040161059c90611448565b805181602001fd5b6001600160e01b031916630a85bd0160e11b149050610d82565b506001949350505050565b600060208284031215611195578081fd5b8135610c1e81611606565b600080604083850312156111b2578081fd5b82356111bd81611606565b915060208301356111cd81611606565b809150509250929050565b6000806000606084860312156111ec578081fd5b83356111f781611606565b9250602084013561120781611606565b929592945050506040919091013590565b6000806000806080858703121561122d578081fd5b843561123881611606565b9350602085013561124881611606565b925060408501359150606085013567ffffffffffffffff8082111561126b578283fd5b818701915087601f83011261127e578283fd5b813581811115611290576112906115f0565b604051601f8201601f19908116603f011681019083821181831017156112b8576112b86115f0565b816040528281528a60208487010111156112d0578586fd5b82602086016020830137918201602001949094529598949750929550505050565b60008060408385031215611303578182fd5b823561130e81611606565b9150602083013580151581146111cd578182fd5b60008060408385031215611334578182fd5b823561133f81611606565b946020939093013593505050565b60006020828403121561135e578081fd5b8135610c1e8161161b565b60006020828403121561137a578081fd5b8151610c1e8161161b565b600060208284031215611396578081fd5b5035919050565b600081518084526113b581602086016020860161152e565b601f01601f19169290920160200192915050565b600083516113db81846020880161152e565b8351908301906113ef81836020880161152e565b01949350505050565b6001600160a01b038581168252841660208201526040810183905260806060820181905260009061142b9083018461139d565b9695505050505050565b602081526000610c1e602083018461139d565b60208082526032908201527f4552433732313a207472616e7366657220746f206e6f6e20455243373231526560408201527131b2b4bb32b91034b6b83632b6b2b73a32b960711b606082015260800190565b60208082526031908201527f4552433732313a207472616e736665722063616c6c6572206973206e6f74206f6040820152701ddb995c881b9bdc88185c1c1c9bdd9959607a1b606082015260800190565b600082198211156114fe576114fe6115c4565b500190565b600082611512576115126115da565b500490565b600082821015611529576115296115c4565b500390565b60005b83811015611549578181015183820152602001611531565b83811115610b375750506000910152565b600181811c9082168061156e57607f821691505b6020821081141561158f57634e487b7160e01b600052602260045260246000fd5b50919050565b60006000198214156115a9576115a96115c4565b5060010190565b6000826115bf576115bf6115da565b500690565b634e487b7160e01b600052601160045260246000fd5b634e487b7160e01b600052601260045260246000fd5b634e487b7160e01b600052604160045260246000fd5b6001600160a01b038116811461089357600080fd5b6001600160e01b03198116811461089357600080fdfea26469706673582212207aa41b6d9d103ba56bbc8b928ea9157a4fc2bcd70a19d637db65c9ed9a9ea6d264736f6c63430008040033"
        
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
        

    
    End Class    
    
    Public Partial Class ApproveFunction
        Inherits ApproveFunctionBase
    End Class

        <[Function]("approve")>
    Public Class ApproveFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "to", 1)>
        Public Overridable Property [To] As String
        <[Parameter]("uint256", "tokenId", 2)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class
    
    
    Public Partial Class BalanceOfFunction
        Inherits BalanceOfFunctionBase
    End Class

        <[Function]("balanceOf", "uint256")>
    Public Class BalanceOfFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "owner", 1)>
        Public Overridable Property [Owner] As String
    
    End Class
    
    
    Public Partial Class CeoAddressFunction
        Inherits CeoAddressFunctionBase
    End Class

        <[Function]("ceoAddress", "address")>
    Public Class CeoAddressFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class CfoAddressFunction
        Inherits CfoAddressFunctionBase
    End Class

        <[Function]("cfoAddress", "address")>
    Public Class CfoAddressFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class CooAddressFunction
        Inherits CooAddressFunctionBase
    End Class

        <[Function]("cooAddress", "address")>
    Public Class CooAddressFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class CooldownsFunction
        Inherits CooldownsFunctionBase
    End Class

        <[Function]("cooldowns", "uint32")>
    Public Class CooldownsFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class
    
    
    Public Partial Class GetApprovedFunction
        Inherits GetApprovedFunctionBase
    End Class

        <[Function]("getApproved", "address")>
    Public Class GetApprovedFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "tokenId", 1)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class
    
    
    Public Partial Class GizzyIndexToApprovedFunction
        Inherits GizzyIndexToApprovedFunctionBase
    End Class

        <[Function]("gizzyIndexToApproved", "address")>
    Public Class GizzyIndexToApprovedFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class
    
    
    Public Partial Class GizzyIndexToOwnerFunction
        Inherits GizzyIndexToOwnerFunctionBase
    End Class

        <[Function]("gizzyIndexToOwner", "address")>
    Public Class GizzyIndexToOwnerFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class
    
    
    Public Partial Class IsApprovedForAllFunction
        Inherits IsApprovedForAllFunctionBase
    End Class

        <[Function]("isApprovedForAll", "bool")>
    Public Class IsApprovedForAllFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "owner", 1)>
        Public Overridable Property [Owner] As String
        <[Parameter]("address", "operator", 2)>
        Public Overridable Property [Operator] As String
    
    End Class
    
    
    Public Partial Class NameFunction
        Inherits NameFunctionBase
    End Class

        <[Function]("name", "string")>
    Public Class NameFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class OwnerOfFunction
        Inherits OwnerOfFunctionBase
    End Class

        <[Function]("ownerOf", "address")>
    Public Class OwnerOfFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "tokenId", 1)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class
    
    
    Public Partial Class PauseFunction
        Inherits PauseFunctionBase
    End Class

        <[Function]("pause")>
    Public Class PauseFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class PausedFunction
        Inherits PausedFunctionBase
    End Class

        <[Function]("paused", "bool")>
    Public Class PausedFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class SafeTransferFromFunction
        Inherits SafeTransferFromFunctionBase
    End Class

        <[Function]("safeTransferFrom")>
    Public Class SafeTransferFromFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "from", 1)>
        Public Overridable Property [From] As String
        <[Parameter]("address", "to", 2)>
        Public Overridable Property [To] As String
        <[Parameter]("uint256", "tokenId", 3)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class
    
    
    Public Partial Class SafeTransferFromFunction
        Inherits SafeTransferFromFunctionBase
    End Class

        <[Function]("safeTransferFrom")>
    Public Class SafeTransferFromFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "from", 1)>
        Public Overridable Property [From] As String
        <[Parameter]("address", "to", 2)>
        Public Overridable Property [To] As String
        <[Parameter]("uint256", "tokenId", 3)>
        Public Overridable Property [TokenId] As BigInteger
        <[Parameter]("bytes", "_data", 4)>
        Public Overridable Property [Data] As Byte()
    
    End Class
    
    
    Public Partial Class SetApprovalForAllFunction
        Inherits SetApprovalForAllFunctionBase
    End Class

        <[Function]("setApprovalForAll")>
    Public Class SetApprovalForAllFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "operator", 1)>
        Public Overridable Property [Operator] As String
        <[Parameter]("bool", "approved", 2)>
        Public Overridable Property [Approved] As Boolean
    
    End Class
    
    
    Public Partial Class SetCEOFunction
        Inherits SetCEOFunctionBase
    End Class

        <[Function]("setCEO")>
    Public Class SetCEOFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_newCEO", 1)>
        Public Overridable Property [NewCEO] As String
    
    End Class
    
    
    Public Partial Class SetCFOFunction
        Inherits SetCFOFunctionBase
    End Class

        <[Function]("setCFO")>
    Public Class SetCFOFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_newCFO", 1)>
        Public Overridable Property [NewCFO] As String
    
    End Class
    
    
    Public Partial Class SetCOOFunction
        Inherits SetCOOFunctionBase
    End Class

        <[Function]("setCOO")>
    Public Class SetCOOFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_newCOO", 1)>
        Public Overridable Property [NewCOO] As String
    
    End Class
    
    
    Public Partial Class SireAllowedToAddressFunction
        Inherits SireAllowedToAddressFunctionBase
    End Class

        <[Function]("sireAllowedToAddress", "address")>
    Public Class SireAllowedToAddressFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class
    
    
    Public Partial Class SupportsInterfaceFunction
        Inherits SupportsInterfaceFunctionBase
    End Class

        <[Function]("supportsInterface", "bool")>
    Public Class SupportsInterfaceFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("bytes4", "interfaceId", 1)>
        Public Overridable Property [InterfaceId] As Byte()
    
    End Class
    
    
    Public Partial Class SymbolFunction
        Inherits SymbolFunctionBase
    End Class

        <[Function]("symbol", "string")>
    Public Class SymbolFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class TokenURIFunction
        Inherits TokenURIFunctionBase
    End Class

        <[Function]("tokenURI", "string")>
    Public Class TokenURIFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "tokenId", 1)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class
    
    
    Public Partial Class TransferFromFunction
        Inherits TransferFromFunctionBase
    End Class

        <[Function]("transferFrom")>
    Public Class TransferFromFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "from", 1)>
        Public Overridable Property [From] As String
        <[Parameter]("address", "to", 2)>
        Public Overridable Property [To] As String
        <[Parameter]("uint256", "tokenId", 3)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class
    
    
    Public Partial Class UnpauseFunction
        Inherits UnpauseFunctionBase
    End Class

        <[Function]("unpause")>
    Public Class UnpauseFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class WithdrawBalanceFunction
        Inherits WithdrawBalanceFunctionBase
    End Class

        <[Function]("withdrawBalance")>
    Public Class WithdrawBalanceFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class ApprovalEventDTO
        Inherits ApprovalEventDTOBase
    End Class

    <[Event]("Approval")>
    Public Class ApprovalEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "owner", 1, true)>
        Public Overridable Property [Owner] As String
        <[Parameter]("address", "approved", 2, true)>
        Public Overridable Property [Approved] As String
        <[Parameter]("uint256", "tokenId", 3, true)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class    
    
    Public Partial Class ApprovalForAllEventDTO
        Inherits ApprovalForAllEventDTOBase
    End Class

    <[Event]("ApprovalForAll")>
    Public Class ApprovalForAllEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "owner", 1, true)>
        Public Overridable Property [Owner] As String
        <[Parameter]("address", "operator", 2, true)>
        Public Overridable Property [Operator] As String
        <[Parameter]("bool", "approved", 3, false)>
        Public Overridable Property [Approved] As Boolean
    
    End Class    
    
    Public Partial Class BirthEventDTO
        Inherits BirthEventDTOBase
    End Class

    <[Event]("Birth")>
    Public Class BirthEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "owner", 1, true)>
        Public Overridable Property [Owner] As String
        <[Parameter]("uint256", "kittyId", 2, false)>
        Public Overridable Property [KittyId] As BigInteger
        <[Parameter]("uint256", "matronId", 3, false)>
        Public Overridable Property [MatronId] As BigInteger
        <[Parameter]("uint256", "sireId", 4, false)>
        Public Overridable Property [SireId] As BigInteger
        <[Parameter]("uint256", "genes", 5, false)>
        Public Overridable Property [Genes] As BigInteger
    
    End Class    
    
    Public Partial Class ContractUpgradeEventDTO
        Inherits ContractUpgradeEventDTOBase
    End Class

    <[Event]("ContractUpgrade")>
    Public Class ContractUpgradeEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "newContract", 1, false)>
        Public Overridable Property [NewContract] As String
    
    End Class    
    
    Public Partial Class TransferEventDTO
        Inherits TransferEventDTOBase
    End Class

    <[Event]("Transfer")>
    Public Class TransferEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "from", 1, true)>
        Public Overridable Property [From] As String
        <[Parameter]("address", "to", 2, true)>
        Public Overridable Property [To] As String
        <[Parameter]("uint256", "tokenId", 3, true)>
        Public Overridable Property [TokenId] As BigInteger
    
    End Class    
    
    
    
    Public Partial Class BalanceOfOutputDTO
        Inherits BalanceOfOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class BalanceOfOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class    
    
    Public Partial Class CeoAddressOutputDTO
        Inherits CeoAddressOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class CeoAddressOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class CfoAddressOutputDTO
        Inherits CfoAddressOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class CfoAddressOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class CooAddressOutputDTO
        Inherits CooAddressOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class CooAddressOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class CooldownsOutputDTO
        Inherits CooldownsOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class CooldownsOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("uint32", "", 1)>
        Public Overridable Property [ReturnValue1] As UInteger
    
    End Class    
    
    Public Partial Class GetApprovedOutputDTO
        Inherits GetApprovedOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class GetApprovedOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class GizzyIndexToApprovedOutputDTO
        Inherits GizzyIndexToApprovedOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class GizzyIndexToApprovedOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class GizzyIndexToOwnerOutputDTO
        Inherits GizzyIndexToOwnerOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class GizzyIndexToOwnerOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class IsApprovedForAllOutputDTO
        Inherits IsApprovedForAllOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class IsApprovedForAllOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("bool", "", 1)>
        Public Overridable Property [ReturnValue1] As Boolean
    
    End Class    
    
    Public Partial Class NameOutputDTO
        Inherits NameOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class NameOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("string", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class OwnerOfOutputDTO
        Inherits OwnerOfOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class OwnerOfOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    
    
    Public Partial Class PausedOutputDTO
        Inherits PausedOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class PausedOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("bool", "", 1)>
        Public Overridable Property [ReturnValue1] As Boolean
    
    End Class    
    
    
    
    
    
    
    
    
    
    
    
    
    
    Public Partial Class SireAllowedToAddressOutputDTO
        Inherits SireAllowedToAddressOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class SireAllowedToAddressOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class SupportsInterfaceOutputDTO
        Inherits SupportsInterfaceOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class SupportsInterfaceOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("bool", "", 1)>
        Public Overridable Property [ReturnValue1] As Boolean
    
    End Class    
    
    Public Partial Class SymbolOutputDTO
        Inherits SymbolOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class SymbolOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("string", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class TokenURIOutputDTO
        Inherits TokenURIOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class TokenURIOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("string", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    
    
    
    

End Namespace
