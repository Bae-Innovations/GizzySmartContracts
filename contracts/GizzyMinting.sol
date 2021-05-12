// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./GizzyOwnership.sol";

contract GizzyMinting is GizzyOwnership{
  
  // limits the number of gizzies the contract owner can ever create
  uint256 public promoCreationLimit = 5000;
  uint256 public gen0CreationLimit = 50000;

  // Constants for gen0 auctions
  uint256 public gen0StartingPrice = 1e10;
  uint256 public gen0AuctionDuration = 1 days;

  // Counts the number of cats the contract owner has created
  uint256 public promoCreatedCount;
  uint256 public gen0CreatedCount;

  function createPromoGizzy(uint256 _genes, address _owner) public onlyCOO {
    if (_owner == address(0)) {
      _owner = cooAddress;
    }
    require(promoCreatedCount < promoCreationLimit);
    require(gen0CreatedCount < gen0CreationLimit);
  
    promoCreatedCount ++;
    gen0CreatedCount ++;
    _createGizzy(0, 0, 0, _genes, _owner);
  }

  // createGen0Auction

  // _computeNextGen0Price


}
