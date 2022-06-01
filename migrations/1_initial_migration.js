const Migrations = artifacts.require("Migrations");
const ItemStorage = artifacts.require("ItemStorage");

module.exports = async function (deployer) {
  deployer.deploy(Migrations);
  deployer.deploy(ItemStorage);

  const storage = await ItemStorage.deployed();
  storage.createItem(0, "Espada Roja", "Espada magica de fuego!", 10, "bafkreieu2gvgngp5fzvhc2nvkpl6b4r2ftrhe6al3lg5gm4o3fvf32mzla");

  storage.addItemToAddress("0x99A556A0E54255e7A4FDE8046BE54394fB7dA17f", 0, 1);
  
};
