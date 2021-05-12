// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./GizzyBase.sol";

contract GizzyOwnership is GizzyBase{

  function implementsERC721() public pure returns (bool){
    return true;
  }

  // checks if the given address is the current owner of the particular gizzy
  // @param _claimant the address that is the alleged owner
  // @param _tokenId gizzy id, only valid when > 0
  function _owns(address _claimant, uint256 _tokenId) internal view returns (bool) {
    return gizzyIndexToOwner[_tokenId] == _claimant;
  }

  // checks if a given address currently has transferApproval for a particular gizzy
  // @param _claimant the address we are confirming the gizzy is for (new future owner)
  // @param _tokenId gizzy id, only valid when > 0
  function _approvedFor(address _claimant, uint256 _tokenId) internal view returns (bool) {
    return gizzyIndexToOwner[_tokenId] == _claimant;
  }

  // @dev Marks an address as being approved for transferFrom(), overwriting any previous
  // approval. Setting _approve() to address(0) clears all transfer approval
  function _approve(uint256 _tokenId, address _approved) internal {
    gizzyIndexToApproved[_tokenId] = _approved;
  }

  function balanceOf(address _owner) override public view returns (uint256 count) {
    return ownershipTokenCount[_owner];
  }

  function transfer(
    address _to,
    uint256 _tokenId
  )
    public
    whenNotPaused
  {
    // Safety check to prevent against an unexpected 0x0 default
    require(_to != address(0));
    // You can only send your own gizzy
    require(_owns(msg.sender, _tokenId));

    _transfer(msg.sender, _to, _tokenId);
  }

  function approve(
    address _to,
    uint _tokenId
  )
    override
    public
    whenNotPaused
  {
    // Only owner can grant transfer approval
    require(_owns(msg.sender, _tokenId));

    // Register the aapproval replacing any previous approval
    _approve(_tokenId, _to);

    // Emit the approval event
    emit Approval(msg.sender, _to, _tokenId);
  }

  function transferFrom(
    address _from,
    address _to,
    uint256 _tokenId
  )
    override
    public
    whenNotPaused
  {
    // Check for approval and valid ownership
    require(_approvedFor(msg.sender, _tokenId));
    require(_owns(_from, _tokenId));
  
    // Reassign ownership (also clears pending approvals and emits Transfer event)
    _transfer(_from, _to, _tokenId);
  }

  function totalSupply() public view returns (uint) {
    return gizzies.length - 1;
  }

  function ownerOf(uint256 _tokenId)
    override
    public
    view
    returns (address owner)
  {
    owner = gizzyIndexToOwner[_tokenId];
    require(owner != address(0));
  }

}
