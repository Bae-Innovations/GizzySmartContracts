// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

contract GizzyWireframe is ERC721{

    constructor() ERC721('Gizzy', 'GZY') {
    paused = false;
    ceoAddress = msg.sender;
    cooAddress = msg.sender;
    _createGizzy(0,0,0,uint256(0),address(0));
    }

    event Birth(address indexed owner, uint256 kittyId, uint256 matronId, uint256 sireId, uint256 genes);

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

    // an array to keep track of all the gizzy structs
    Gizzy[] gizzies;

    // mapping (uint256 => address) public gizzyIndexToOwner;

    // mapping (uint256 => address) public gizzyIndexToApproved;

    // mapping (uint256 => address) public sireAllowedToAddress;

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

        _safeMint(_owner, newGizzyId);
        // _setTokenURI(newGizzyId, tokenURI)

        return newGizzyId;

    }


    // 
    // Auction Contract
    //

    struct Auction{
        address owner;
        uint256 gizzyId;
        uint256 highestBid;
        address payable highestBidder;
        uint256 duration;
        uint256 creationTime;
        bool auctionEnded;
    }

    Auction[] auctions;

    event AuctionStarted(address owner, uint256 gizzyId);
    event Bid(address bidder, uint256 auctionId, uint256 amount);

    function startAuction(uint256 _gizzyId, uint256 _startingPrice, uint256 _duration) public {
        // inputs: gizzyId, startingPrice, timeLimit
        // checks: if sender owns gizzy, if gizzy is free from auctions
        
        // creates auctions, sends gizzy to this contract, 
        Auction memory _auction = Auction({
            owner: msg.sender,
            gizzyId: _gizzyId,
            highestBid: _startingPrice,
            highestBidder: payable(address(0)),
            duration: _duration,
            creationTime: block.timestamp,
            auctionEnded: false
        });
        // send the gizzy to this contract

        auctions.push(_auction);
        
        emit AuctionStarted(msg.sender, _gizzyId);
        // emits an auction event
    }

    function placeBid(uint256 _auctionId) public payable {
        // checks if the amount is more than the current highest amount
        Auction storage _auction = auctions[_auctionId];
        
        // requires more than highest bid

        // refunds the previous bid to the previous owner
        // refund should not send any if address is (0)
        _auction.highestBidder.transfer(address(this).balance);
        
        // places a bid
        _auction.highestBid = msg.value;
        _auction.highestBidder = payable(msg.sender);
        
        // emits an event that bid has been placed
        emit Bid(msg.sender, _auctionId, msg.value);
    }

    function endAuction(uint256 _auctionId) public {
        // checks if the given auction is supposed to end
        // ends the auction if its supposed to end
        Auction storage _auction = auctions[_auctionId];

        if (_auction.creationTime + _auction.duration > block.timestamp){
            // TODO: send the nft to the auction winner
            // TODO: send the money to the seller (after keeping the commission)
            _auction.auctionEnded = true;
        }
        
    }



    //
    // Breeding Contract
    //
    uint256 BreedingFee;
    event Breed(uint256 matronId, uint256 sireId, address owner);

    function BreedGizzy(uint256 _matronId, uint256 _sireId) 
        public 
        payable
    {
        _owner = msg.sender;
        _fee = msg.value;

        // requires requester to own the gizzy
        // requires the fee to be at or above the fee        

        emit Breed(_matronId, _sireId, _owner);
    }

    function GizzyBirth(address _owner, uint256 _genes, uint32 matronId, uint32 _sireId uint16 _generation)
        public onlyCOO 
    {
        owner = _owner;
        genes = _genes;
        matronId = matronId;
        sireId = sireId;
        generation = _generation;

        _createGizzy()
    }
    


    //
    // Minting Contract
    //
    // limits the number of gizzies the contract owner can ever create
    uint256 public promoCreationLimit = 5000;
    uint256 public gen0CreationLimit = 50000;

    // Constants for gen0 auctions
    uint256 public gen0StartingPrice = 1e10;
    uint256 public gen0AuctionDuration = 1 days;

    // Counts the number of gizzies the contract owner has created
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
      uint256 generation,
      uint256 genes
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
      genes = giz.genes;
    }

}