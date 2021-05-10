// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./GizzyAccessControl.sol";

contract GizzyBase {
  
  // @dev the Birth event is fired whenever a new kitten comes into existence. This 
  // includes cats created through giveBirth method and also newly minted gen cats
  event Birth(address indexed owner, uint256 kittyId, uint256 matronId, uint256 sireId, uint256 genes);

  // @dev Transfer event as defined in current draft of ERC721. Emitted every time a kitten
  // ownership is assigned, including births.
  event Transfer(address indexed from, address indexed to, uint256 indexed tokenId);

  struct Gizzy {
    uint256 genes;
    uint64 birthTime;
    uint64 cooldownEndTime;
    uint32 matronId;
    uint32 sireId;
    uint32 siringWithId;
    uint16 cooldownIndex;
    uint16 generation;
  }

  uint32[14] public cooldowns = [
    uint32(1 minutes),
    uint32(2 minutes),
    uint32(5 minutes),
    uint32(10 minutes),
    uint32(30 minutes),
    uint32(1 hours),
    uint32(2 hours),
    uint32(4 hours),
    uint32(8 hours),
    uint32(16 hours),
    uint32(1 days),
    uint32(2 days),
    uint32(4 days),
    uint32(7 days)
  ];

  Gizzy[] gizzies;

  mapping (uint256 => address) public kittyIndexToOwner;

  mapping (address => uint256) ownershipTokenCount;

  mapping (uint256 => address) public kittyIndexToApproved;

  mapping (uint256 => address) public sireAllowedToAddress;

  //function _transfer

  //function _createKitty

  // when u figure out how and where _createKitty is used, figure out how to create and use a 
  // _createItem function and everything that uses it

}
