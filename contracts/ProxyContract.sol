// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "@openzeppelin/contracts/proxy/transparent/TransparentUpgradeableProxy.sol";

contract ProxyContract is TransparentUpgradeableProxy{
    constructor(address _logicAddress, address _adminAddress) TransparentUpgradeableProxy(_logicAddress, _adminAddress, bytes("")){}
}