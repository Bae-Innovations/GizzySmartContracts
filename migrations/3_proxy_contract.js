const Migrations = artifacts.require("ProxyContract");
const logic_address = '0x23B02b37f112607d6eBC56a0061A0B0f5f2e3bc9'

module.exports = function (deployer) {
  deployer.deploy(Migrations, logic_address);
};0x2Ff08B78ea6667Dc61ee3A638A93a5337D72D180