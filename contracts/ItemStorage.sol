// SPDX-License-Identifier: MIT
pragma solidity 0.8.11;

contract ItemStorage {


   mapping(uint => uint) private id2Balance;
   mapping(address =>  mapping (uint => uint)) private address2Balances;

   mapping(uint => Item) itemStats;
   uint itemTypes;

   struct Item {
      uint idType;
      string name;
      string description;
      uint damage;
   }

   function createItem(uint _idType, string memory _name , string memory _description , uint damage, address _owner) public returns (Item memory) {
      Item memory newItem = Item(_idType, _name, _description, damage);
      itemStats[_idType] = newItem;
      address2Balances[_owner][_idType] = address2Balances[_owner][_idType] + 1;

      itemTypes = itemTypes + 1;

      return newItem;

   }

   function getBalances() public view returns ( uint[] memory ){

      uint auxint = itemTypes;
      uint[] memory balances = new uint[](auxint);
      mapping(uint => uint) storage auxMap = address2Balances[msg.sender];

      for(uint i = 0; i < auxint; i++) {
            balances[i] = auxMap[i];
      }


      return balances;
   }

 }  