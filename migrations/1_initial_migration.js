const Migrations = artifacts.require("Migrations");
const ItemStorage = artifacts.require("ItemStorage");

module.exports = function (deployer) {
  deployer.deploy(Migrations);
  deployer.deploy(ItemStorage);
};
