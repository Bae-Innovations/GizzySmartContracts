// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./GizzyMinting.sol";

contract GizzyCore is GizzyMinting{
  constructor() {
    paused = true;
    ceoAddress = msg.sender;
    cooAddress = msg.sender;
    _createGizzy(0,0,0,uint256(0),address(0));
  }

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
