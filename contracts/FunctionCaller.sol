// SPDX-License-Identifier: MIT
// compiler version must be greater than or equal to 0.8.10 and less than 0.9.0
pragma solidity ^0.8.7;

import './ItemStorage.sol';

contract FunctionCaller {

    function  callName(address a) public view returns (string memory) {
        ItemStorage item = ItemStorage(a);

        item.getDmg();
        return item.name();
    }
}

