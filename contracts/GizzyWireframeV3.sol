// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";

contract GizzyWireframe is ERC721URIStorage{

    constructor() ERC721('Gizzy', 'GZY') {
    _createGizzy(0,0,0,"asd",msg.sender,true);
    }

    event Birth(address indexed owner, uint256 kittyId, uint256 matronId, uint256 sireId, string tokenURI);

    struct Gizzy {
        uint64 birthTime;
        uint64 cooldownEndTime;
        uint32 matronId;
        uint32 sireId;
        uint32 siringWithId;
        uint16 generation;
        uint8 cooldownIndex;
        bool breedable;
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

    // an array to keep track of all the gizzy structs
    Gizzy[] gizzies;

    function _createGizzy(
        uint256 _matronId,
        uint256 _sireId,
        uint256 _generation,
        string memory _tokenURI,
        address _owner,
        bool _breedable
    )
        internal
        returns (uint)

    {
        require(_matronId <= 4294967295);
        require(_sireId <= 4294967295);
        require(_generation <= 65535);
    
        Gizzy memory _gizzy = Gizzy({
            birthTime: uint64(block.timestamp),
            cooldownEndTime: 0,
            matronId: uint32(_matronId),
            sireId: uint32(_sireId),
            siringWithId: 0,
            cooldownIndex: 0,
            generation: uint16(_generation),
            breedable: bool (_breedable)
        });

        gizzies.push(_gizzy);
        uint256 newGizzyId = gizzies.length - 1;

        require(newGizzyId <= 4294967295);

        emit Birth(
        _owner,
        newGizzyId,
        uint256(_gizzy.matronId),
        uint256(_gizzy.sireId),
        string(_tokenURI)
        );

        _safeMint(_owner, newGizzyId);
        _setTokenURI(newGizzyId, _tokenURI);
        

        return newGizzyId;

    }


    // called by server
    function GizzyBirth(uint32 _matronId, uint32 _sireId, uint32 _generation, string memory _tokenURI, address _owner, bool _breedable)
        public
    {
        // create a gizzy and set its tokenURI
        _createGizzy(_matronId, _sireId, _generation, _tokenURI, _owner, _breedable);
        
    }
    
    // limits the number of gizzies the contract owner can ever create
    uint256 public promoCreationLimit = 5000;
    uint256 public gen0CreationLimit = 50000;

    // Constants for gen0 auctions
    uint256 public gen0StartingPrice = 1e10;
    uint256 public gen0AuctionDuration = 1 days;

    // Counts the number of gizzies the contract owner has created
    uint256 public promoCreatedCount;
    uint256 public gen0CreatedCount;

    // called by admin
    function createPromoGizzy(string memory _tokenURI, address _owner, bool _breedable) public {

        // set owner to whoever gizzy is being gifted
        // when promo gizzy is auctioned, gift to their own account and then start auction

        require(promoCreatedCount < promoCreationLimit);
        require(gen0CreatedCount < gen0CreationLimit);
    
        promoCreatedCount ++;
        gen0CreatedCount ++;
        _createGizzy(0, 0, 0, _tokenURI, _owner, _breedable);
    }

    //
    // Core Contract that is deployed
    //
    function getGizzy(uint256 _id)
    public
    view
    returns (
      bool isGestating,
      bool isReady,
      uint256 cooldownIndex,
      uint256 nextActionAt,
      uint256 siringWithId,
      uint256 birthTime,
      uint256 matronId,
      uint256 sireId,
      uint256 generation
      // uint256 genes instead show tokenURI
    ) {
      Gizzy storage giz = gizzies[_id];

      isGestating = (giz.siringWithId != 0);
      isReady = (giz.cooldownEndTime <= block.timestamp);
      cooldownIndex = uint256(giz.cooldownIndex);
      nextActionAt = uint256(giz.cooldownEndTime);
      siringWithId = uint256(giz.siringWithId);
      birthTime = uint256(giz.birthTime);
      matronId = uint256(giz.matronId);
      sireId = uint256(giz.sireId);
      generation = uint256(giz.generation);
      // genes = giz.genes; instead show tokenURI
    }

}
