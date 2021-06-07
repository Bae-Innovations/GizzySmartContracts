const Migrations = artifacts.require("GizzyWireframe");

module.exports = function (deployer) {
  deployer.deploy(Migrations);
};
