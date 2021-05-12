// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./GizzyAccessControl.sol";
import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

contract GizzyBase is GizzyAccessControl, ERC721{
  
  constructor() ERC721('Gizzy', 'GZY') {
  }
  // @dev the Birth event is fired whenever a new kitten comes into existence. This 
  // includes cats created through giveBirth method and also newly minted gen cats
  event Birth(address indexed owner, uint256 kittyId, uint256 matronId, uint256 sireId, uint256 genes);

  // @dev Transfer event as defined in current draft of ERC721. Emitted every time a kitten
  // ownership is assigned, including births.
  // event Transfer(address indexed from, address indexed to, uint256 indexed tokenId);

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

  mapping (uint256 => address) public gizzyIndexToOwner;

  mapping (address => uint256) ownershipTokenCount;

  mapping (uint256 => address) public gizzyIndexToApproved;

  mapping (uint256 => address) public sireAllowedToAddress;

  function _transfer(address _from, address _to, uint256 _tokenId) internal override{
    ownershipTokenCount[_to] ++;
    gizzyIndexToOwner[_tokenId] = _to;
    if (_from != address(0)) {
      ownershipTokenCount[_from] ++;
      delete sireAllowedToAddress[_tokenId];
      delete gizzyIndexToApproved[_tokenId];
    }

    emit Transfer(_from, _to, _tokenId);
  }

  function _createGizzy(
    uint256 _matronId,
    uint256 _sireId,
    uint256 _generation,
    uint256 _genes,
    address _owner
  )
    internal
    returns (uint)

  {
    require(_matronId <= 4294967295);
    require(_sireId <= 4294967295);
    require(_generation <= 65535);
  
    Gizzy memory _gizzy = Gizzy({
      genes: _genes,
      birthTime: uint64(block.timestamp),
      cooldownEndTime: 0,
      matronId: uint32(_matronId),
      sireId: uint32(_sireId),
      siringWithId: 0,
      cooldownIndex: 0,
      generation: uint16(_generation)
    });

    gizzies.push(_gizzy);
    uint256 newGizzyId = gizzies.length - 1;

    require(newGizzyId <= 4294967295);

    emit Birth(
      _owner,
      newGizzyId,
      uint256(_gizzy.matronId),
      uint256(_gizzy.sireId),
      _gizzy.genes
    );

    _transfer(address(0), _owner, newGizzyId);

    return newGizzyId;

  }

  // when u figure out how and where _createKitty is used, figure out how to create and use a 
  // _createItem function and everything that uses it

}
