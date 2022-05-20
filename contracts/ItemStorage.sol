// SPDX-License-Identifier: MIT
pragma solidity 0.8.11;

contract ItemStorage {

   mapping (uint => uint) id2Balance;
   mapping (address = > id2balance) address2Balances;

   mapping(uint => Item) itemStats;

   struct Item {
      uint idType;
      string name;
      string description;
      uint damage;
   }

   function createItem(uint _idType, string _name, string _description, uint damage, address _owner) public returns (Item) {
      Item newItem = Item(_idType, _name, _description, damage);
      itemStats[_idType] = newItem;
      address2Balances[_owner][_idType] = address2Balances[_owner][_idType] + 1;

      return newItem;

   }

   function getBalances() public returns (id2balance){
      return address2Balances[msg.sender];
   }

 }