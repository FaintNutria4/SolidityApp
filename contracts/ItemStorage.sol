// SPDX-License-Identifier: MIT
pragma solidity 0.8.11;

contract ItemStorage {


   address owner;

   mapping(address => mapping (uint => uint)) private address2Balances;

   mapping(uint => Item) itemStats;
   uint itemTypes = 1;

   struct Item {
      uint idType;
      string name;
      string description;
      uint damage;
      string cid;
   }

   //Buy from somebody

   mapping(address => Offer[]) Address2Offers;

   struct Offer {
      address buyer;
      address seller;
      uint itemId;
      uint amount;
      uint gold;
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

   modifier hasItems(uint _idType, uint _amount) {
      require(address2Balances[msg.sender][_idType] >= _amount);
      _;
   }

   modifier notGold(uint _idType){
      require(_idType != 0);
      _;
   }

   modifier hasGold(address _adr, uint _gold){
      require(address2Balances[_adr][0] >= _gold);
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

   function transferItemToAddress(address _newOwner, uint _idType, uint _amount, uint _gold) 
   public
   onlyOwner
   notGold(_idType) 
   hasItems(_idType, _amount)

   {
      address2Balances[_newOwner][0] -= _gold;
      address2Balances[msg.sender][0] += _gold;

      address2Balances[msg.sender][_idType] -= _amount;
      address2Balances[_newOwner][_idType] += _amount;

   }

   function addItemToAddress(address _newOwner, uint _idType, uint _items) 
   public 
   onlyOwner 
   itemExists(_idType) 
   {
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

   function getOffersList() public view returns (Offer[] memory){
      return Address2Offers[msg.sender];
   }

   function makeOffer(
   address _buyer,
   address _seller,
   uint _itemId,
   uint _amount,
   uint _gold)
   public 
   itemExists(_itemId) 
   {
      Offer[] storage offers = Address2Offers[_seller];
      Offer memory newOffer = Offer( _buyer, _seller, _itemId, _amount, _gold);
      offers.push(newOffer);
   }  


   function answerOfferExternal(uint index, bool answer) external {
      Offer[] memory offers = Address2Offers[msg.sender];
      answerOffer(offers[index], index, answer);
   }

   function answerOffer(Offer memory offer, uint index, bool answer) 
   private 
   notGold(offer.itemId)
   hasItems(offer.itemId, offer.amount)
   hasGold(offer.buyer, offer.gold)
   {
      if(answer){

         mapping(uint => uint) storage sellerBalances = address2Balances[offer.seller];
         mapping(uint => uint) storage buyerBalances = address2Balances[offer.buyer];

         buyerBalances[0] = buyerBalances[0] - offer.gold;
         sellerBalances[0] = sellerBalances[0] + offer.gold;

         sellerBalances[offer.itemId] = sellerBalances[offer.itemId] - offer.amount;
         buyerBalances[offer.itemId] = buyerBalances[offer.itemId] + offer.amount;
      }
         

         popItemFromArray(msg.sender, index);
   }

   function getItemsNumber() view external returns(uint) {
      return itemTypes;
   }

   function popItemFromArray(address OfferSeller, uint index) private {
      Offer[] storage offers = Address2Offers[OfferSeller];
      for(uint i = index; i < offers.length-1; i++){
         offers[i] = offers[i+1];      
      }
      offers.pop();
  }

 }  