// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import './GizzyBase.sol';

contract GizzyAuction is GizzyBase {
    
    struct Auction{
        address owner;
        uint256 gizzyId;
        uint256 highestBid;
        address highestBidder;
        uint256 duration;
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
            highestBidder: address(0),
            duration: _duration
        });

        auctions.push(_auction);
        
        emit AuctionStarted(msg.sender, _gizzyId);
        // emits an auction event
    }

    function placeBid(uint256 _auctionId) public payable {
        // checks if the amount is more than the current highest amount
        Auction storage _auction = auctions[_auctionId];
        // requires more than highest bid
        _auction.highestBid = msg.value;
        _auction.highestBidder = msg.sender;
        
        // places a bid
        // refunds the previous bid to the previous owner
        // emits an event that bid has been placed
    }

    function endAuction(uint256 auctionId) public {
        // checks if the given auction is supposed to end
        // ends the auction if its supposed to end
    }

}