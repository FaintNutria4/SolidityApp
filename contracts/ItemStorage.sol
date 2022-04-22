// SPDX-License-Identifier: MIT
pragma solidity 0.8.11;

contract ItemStorage {

   Struct ItemInfo {

      string public name;
      uint private id;
      uint private dmg;
   }

   mapping(uint => uint) public idToValueMap;
   mapping(address => IdToValueMap) public ownerships;
   mapping(uint => ItemInfo) public idToItemInfo; 


    constructor(uint _id,  string memory _name, uint _dmg) {
        id = _id;
        name = _name;
        dmg = _dmg;
    }

    function  getId() public view returns (uint) {
       return id;
    }

    function  getDmg() public view returns (uint) {
       return dmg;
    }
}