// SPDX-License-Identifier: MIT
pragma solidity 0.8.11;

contract ItemStorage {

      mapping (uint => uint) id2Balance;
      mapping (address = > id2balance) address2Balances;

    struct Item {
      uint idType;
      string name;
      string description;
      uint damage;
    }

    constructor() {

    }

    function  getId() public view returns (uint) {
       return id;
    }

    function  getDmg() public view returns (uint) {
       return dmg;
    }
}