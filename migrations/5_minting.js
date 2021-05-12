const Migrations = artifacts.require("GizzyMinting");

module.exports = function (deployer) {
  deployer.deploy(Migrations);
};
