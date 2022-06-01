// SPDX-License-Identifier: MIT
pragma solidity 0.8.11;

contract ItemStorage {


   address owner;

   mapping(address => mapping (uint => uint)) private address2Balances;

   mapping(uint => Item) itemStats;
   uint itemTypes;

   struct Item {
      uint idType;
      string name;
      string description;
      uint damage;
      string cid;
   }

   constructor() {
      owner = msg.sender;
   }

   modifier onlyOwner {
      require(msg.sender == owner);
      _;
   }

   modifier itemExists(uint _idType) {
      require(_idType<itemTypes);
      _;
   }

   function createItem(uint _idType, string memory _name, string memory _description, uint _damage, string memory _cid) 
      public 
      onlyOwner 
      returns (Item memory)  
   {
      Item memory newItem = Item(_idType, _name, _description, _damage, _cid);
      itemStats[_idType] = newItem;

      itemTypes = itemTypes + 1;

      return newItem;

   }

   function addItemToAddress(address _newOwner, uint _idType, uint _items) public onlyOwner {
      mapping(uint => uint) storage balances = address2Balances[_newOwner];
      balances[_idType] = balances[_idType] + _items;
   }

   function getBalances() public view returns (uint[] memory) {

      uint auxint = itemTypes;
      uint[] memory balances = new uint[](auxint);
      mapping(uint => uint) storage auxMap = address2Balances[msg.sender];

      for(uint i = 0; i < auxint; i++) {
            balances[i] = auxMap[i];
      }


      return balances;
   }

   function getItemStats(uint _idType) public view itemExists(_idType) returns (Item memory) {
      return itemStats[_idType];
   }

 }  