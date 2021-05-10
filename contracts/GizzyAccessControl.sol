// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

contract GizzyAccessControl {

  //--------------------------------------------------------------------------------------------
  //Roles and responsiblities:
  // CEO: Can assign other roles and change the address of our dependent smart contracts.
  //      It is also the only role that can unpause the smart contract. It is initially set to
  //      the address that created the smart contract in the GizzyCore constructor
  //
  // CFO: Can withdraw funds from GizzyCore and its auction contracts.
  //
  // COO: Can release gen0 gizzies to auction and mint promo gizzies.
  //--------------------------------------------------------------------------------------------

  // @dev Emited when contract is upgraded.
  event ContractUpgrade(address newContract);

  // Addresses of the special accounts.
  address public ceoAddress;
  address payable public cfoAddress;
  address public cooAddress;

  // @dev Keeps track of whether the contracts is paused. If it is, most actions are blocked.
  bool public paused = false;

  // @dev Access modifier for CEO-only functions.
  modifier onlyCEO() {
    require(msg.sender == ceoAddress);
    _;
  }

  // @dev Access modifier for CFO-only functions.
  modifier onlyCFO() {
    require(msg.sender == cfoAddress);
    _;
  }

  // @dev Access modifier for COO-only functions.
  modifier onlyCOO() {
    require(msg.sender == cooAddress);
    _;
  }

  // @dev Access modifier for C-Level-only functions.
  modifier onlyCLevel() {
    require(
      msg.sender == cooAddress ||
      msg.sender == ceoAddress ||
      msg.sender == cfoAddress
    );
    _;
  }

  // @dev Assigns a new address to act as the CEO. Only available to current CEO.
  // @param _newCEO The address of the new CEO.
  function setCEO(address _newCEO) public onlyCEO {
    require(_newCEO != address(0));

    ceoAddress = _newCEO;
  }

  // @dev Assigns a new address to act as the CFO. Only available to current CEO.
  // @param _newCFO The address of the new CFO.
  function setCFO(address payable _newCFO) public onlyCEO {
    require(_newCFO != address(0));

    cfoAddress = _newCFO;
  }

  // @dev Assigns a new address to act as the COO. Only available to current CEO.
  // @param _newCOO The address of the new COO.
  function setCOO(address _newCOO) public onlyCEO {
    require(_newCOO != address(0));

    cooAddress = _newCOO;
  }

  function withdrawBalance() external onlyCFO {
    cfoAddress.transfer(address(this).balance);
  }

  // @dev Modifier to allow actions only when the contract IS NOT paused.
  modifier whenNotPaused() {
    require(!paused);
    _;
  } 

  // @dev Modifier to allow actions only when the contract IS paused
  modifier whenPaused() {
    require(paused);
    _;
  }

  // @dev Called by any C-level role to pause the contract. Used only when
  // a bug or expoit is detected and we need to limit damange.
  function pause() public onlyCLevel whenNotPaused {
    paused = true;
  }

  // @dev Unpaused the smart contract. Can only be called by the CEO, since 
  // one reason we may pause the contract is when CFO or COO accounts are 
  // compromised
  function unpause() public onlyCEO whenPaused {
    paused = false;
  }

}
