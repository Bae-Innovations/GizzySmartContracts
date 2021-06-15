// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;
 
import "@openzeppelin/contracts-upgradeable/token/ERC721/extensions/ERC721URIStorageUpgradeable.sol";
 
contract GizzyBase is ERC721URIStorageUpgradeable{
 
    function initialize() public {
        __ERC721_init("Gizzy", "GZY");
        adminAddress = msg.sender;
        _createGizzy(0,0,0,msg.sender,false,"null");
    }
 
    address public adminAddress;
    address public serverAddress;
    address payable public accountantAddress;
 
    bool public paused = false;
 
    modifier onlyAdmin() {
        require(msg.sender == adminAddress);
        _;
    }
 
    modifier onlyAccountant() {
        require(msg.sender == accountantAddress);
        _;
    }

    modifier onlyServer() {
        require(msg.sender == serverAddress);
        _;
    }

    modifier onlyAuthority() {
        require(
            msg.sender == adminAddress ||
            msg.sender == serverAddress\
        );
        _;
    }

    function setAdmin(address _newAdmin) public onlyAdmin {
        require(_newAdmin != address(0));
 
        adminAddress = _newAdmin;
    }
 
 
    function setServer(address _newServer) public onlyAdmin {
        require(_newServer != address(0));
 
        serverAddress = _newServer;
    }
 
    function setAccountant(address payable _newAccountant) public onlyAdmin {
        require(_newAccountant != address(0));
 
        serverAddress = _newAccountant;
    }

    function withdrawBalance() external onlyAccountant {
        // keep track of actual balance and send that balance
        accountantAddress.transfer(address(this).balance);
    }
 
    modifier whenNotPaused() {
        require(!paused);
        _;
    }
 
    modifier whenPaused {
        require(paused);
        _;
    }
 
    function pause() public onlyAdmin whenNotPaused {
        paused = true;
    }
 
    function unpause() public onlyAdmin whenPaused {
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
    Gizzy[] public gizzies;
 
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
 
    // called by admin
    function createPromoGizzy(address _owner, bool _breedable, string memory _tokenURI) public onlyAuthority whenNotPaused {
 
        // set owner to whoever gizzy is being gifted
        // when promo gizzy is auctioned, gift to their own account and then start auction

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
      string tokenURI
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
      tokenURI = tokenURI(_id);
    }
 
}
