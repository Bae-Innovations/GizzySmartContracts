const Migrations = artifacts.require("ProxyContract");

module.exports = function (deployer) {
  deployer.deploy(Migrations);
};