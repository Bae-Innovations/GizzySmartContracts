const Migrations = artifacts.require("ProxyContract");
const logic_address = '0xa2B3F9466B4C84eB6AD4BC70fd9d4CD583cAa1Fe'

module.exports = function (deployer) {
  deployer.deploy(Migrations, logic_address);
};