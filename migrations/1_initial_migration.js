const Migrations = artifacts.require("Migrations");
const ItemStorage = artifacts.require("ItemStorage");
const FunctionCaller = artifacts.require("FunctionCaller");

module.exports = function (deployer) {
  deployer.deploy(Migrations);
  deployer.deploy(ItemStorage, 1, "Rompe Huesos", 15);
  deployer.deploy(FunctionCaller);
};
