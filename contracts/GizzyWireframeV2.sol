// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";

contract GizzyWireframe is ERC721URIStorage{

    constructor() ERC721('Gizzy', 'GZY') {
        _createGizzy(0,0,0,msg.sender,false,"null");
        ownerAddress = msg.sender;
    }

    address public ownerAddress;
    address public serverAddress;

    bool public paused = false;

    modifier onlyOwner() {
        require(msg.sender == ownerAddress);
        _;
    }

    modifier onlyServer() {
        require(msg.sender == serverAddress);
        _;
    }

    function setOwner(address _newOwner) public onlyOwner {
        require(_newOwner != address(0));

        ownerAddress = _newOwner;
    }


    function setServer(address _newServer) public onlyOwner {
        require(_newServer != address(0));

        serverAddress = _newServer;
    }

    function withdrawBalance() external onlyOwner {
        // keep track of actual balance and send that balance
        // cfoAddress.transfer(this.balance);
    }

    modifier whenNotPaused() {
        require(!paused);
        _;
    }

    modifier whenPaused {
        require(paused);
        _;
    }

    function pause() public onlyOwner whenNotPaused {
        paused = true;
    }

    function unpause() public onlyOwner whenPaused {
        // can't unpause if contract was upgraded
        paused = false;
    }

    event Birth(uint256 kittyId, uint256 matronId, uint256 sireId, address indexed owner, string tokenURI);

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
        address _owner,
        bool _breedable,
        string memory _tokenURI
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
        newGizzyId,
        uint256(_gizzy.matronId),
        uint256(_gizzy.sireId),
        _owner,
        string(_tokenURI)
        );

        _safeMint(_owner, newGizzyId);
        _setTokenURI(newGizzyId, _tokenURI);
        
        return newGizzyId;

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
    function createPromoGizzy(address _owner, bool _breedable, string memory _tokenURI) public onlyOwner whenNotPaused {

        // set owner to whoever gizzy is being gifted
        // when promo gizzy is auctioned, gift to their own account and then start auction

        require(promoCreatedCount < promoCreationLimit);
        require(gen0CreatedCount < gen0CreationLimit);
    
        promoCreatedCount ++;
        gen0CreatedCount ++;
        _createGizzy(0, 0, 0, _owner, _breedable, _tokenURI);
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
