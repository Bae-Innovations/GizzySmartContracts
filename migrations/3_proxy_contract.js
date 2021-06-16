const Migrations = artifacts.require("ProxyContract");
const logic_address = '0x5bbdF161E65c5020169979Ae7520a7f31a8c6E53'

module.exports = function (deployer) {
  deployer.deploy(Migrations, logic_address);
};