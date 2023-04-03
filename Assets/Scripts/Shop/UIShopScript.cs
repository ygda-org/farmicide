using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShopScript : MonoBehaviour
{
    // SHOP INITIALIZATION STUFF
    public Collider2D shopTrigger;

    public GameObject shopUIContainer; 
    public GameObject shopItemUIPrefab;
    
    public float shopItemSpacing;

    public Vector2 defaultShopUIPosition; // unused currently



    // SHOP INTERACTION STUFF
    public PlayerScript currentPlayer;


    [System.Serializable]
    public enum ItemTypes {
        gun,
        plant,
        troop
    }

    [System.Serializable]
    public struct ShopItemData {
        public ShopItemData(string name_, int cost_, ItemTypes itemType_, SpriteRenderer icon_ = null, GameObject itemObject_ = null) {
            name = name_;
            cost = cost_;
            icon = icon_;
            itemType = itemType_;
            itemObject = itemObject_;
        }
        public string name;
        public int cost;
        public ItemTypes itemType;
        public SpriteRenderer icon;
        public GameObject itemObject;
    }

    [SerializeField]
    public ShopItemData[] availableShopItems = new ShopItemData[1];
    public List<GameObject> shopItemUIs;


    // this selectedShopItem variable is meant to be immutable and only set by the game designer
    [SerializeField]
    private GameObject selectedShopItem;
    private int selectedShopItemIndex;

    // these make it so that when you press down it doesn't repeatedly press down for every frame
    public int totalMenuWaitFrames = 25;
    public int menuWaitCounter = 0;

    


    private void createItemButton(string itemName, int itemCost, int positionIndex){ //add sprite param later


        GameObject shopItemUI = Instantiate(shopItemUIPrefab, shopUIContainer.transform);
        shopItemUIs.Add(shopItemUI);
        shopItemUI.transform.SetParent(shopUIContainer.transform);

        ShopItemHandler shopItemHandler = shopItemUI.GetComponent<ShopItemHandler>();

        float shopItemHeight = 8f;
        
        shopItemUI.transform.position = shopItemUI.transform.position + new Vector3(0, - shopItemHeight * positionIndex * 0.1f, 0);  //change the float multiplier if ui design is changed

        shopItemHandler.setCostText(itemCost);
        shopItemHandler.setNameText(itemName);


        if (positionIndex == 0) setSelectedShopItem(0);
    }

    public void hideUI(){
        shopUIContainer.SetActive(false);
    }

    public void showUI(){
        shopUIContainer.SetActive(true);
    }

    void setSelectedShopItem(int newShopItemIndex) {
        if (selectedShopItem != null) 
            selectedShopItem.GetComponent<ShopItemHandler>().deselect();
        
        // make sure when you try to go out of bounds it wraps back to the beginning of the list
        // for some reason % in c# is remainder instead of modulo so theres no good and readable way to combine these statements sorry
        if (newShopItemIndex < 0) newShopItemIndex = shopItemUIs.Count-1;
        else newShopItemIndex = newShopItemIndex%shopItemUIs.Count;

        if (newShopItemIndex < 0) print(newShopItemIndex);
        selectedShopItem = shopItemUIs[newShopItemIndex];
        selectedShopItemIndex = newShopItemIndex;
        selectedShopItem.GetComponent<ShopItemHandler>().select();
    }
    private void buySelectedItem(PlayerScript player){
        ShopItemData currentItem = availableShopItems[selectedShopItemIndex];
        player.setMoney(player.getMoney()-currentItem.cost);

        if (currentItem.itemType == ItemTypes.gun)
            player.currentGun = currentItem.itemObject;
        
        if (currentItem.itemType == ItemTypes.troop)
            player.currentTroop = currentItem.itemObject;
        
        if (currentItem.itemType == ItemTypes.plant)
            player.currentPlant = currentItem.itemObject;
    }

    void Awake(){

        for (int i = 0; i < availableShopItems.Length; i++) {
            ShopItemData item = availableShopItems[i];
            createItemButton(item.name, item.cost, i);
        }

        hideUI();
        
    }

    void takePlayerInput() {
        if (currentPlayer.movementInput.y > 0.5 && menuWaitCounter <= 0) {
            setSelectedShopItem(--selectedShopItemIndex);
            menuWaitCounter = totalMenuWaitFrames;
        }

        if (currentPlayer.movementInput.y < -0.5 && menuWaitCounter <= 0){
            setSelectedShopItem(++selectedShopItemIndex);
            menuWaitCounter = totalMenuWaitFrames;
        }

        if (currentPlayer.isPressedInteract && menuWaitCounter == -1) {
            if (currentPlayer.getMoney() >= availableShopItems[selectedShopItemIndex].cost)
                buySelectedItem(currentPlayer);

            menuWaitCounter = totalMenuWaitFrames;
        }
        

        if (menuWaitCounter > 0) menuWaitCounter--;

        if (currentPlayer.movementInput.y < 0.5 
        &&  currentPlayer.movementInput.y > -0.5
        &&  currentPlayer.isPressedInteract == false
            )
            menuWaitCounter = -1;
        

        if (currentPlayer.isPressedShoot && menuWaitCounter <= 0) {
            currentPlayer.enableMovement();
            currentPlayer = null;
            hideUI();
        }    
    }


    void FixedUpdate() {
    
        if (currentPlayer != null) 
            takePlayerInput();
        
                
            
    }

    // activate shop
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            currentPlayer = collider.gameObject.GetComponent<PlayerScript>();
            currentPlayer.disableMovement();
            showUI();
        }
    }
    
    // private void OnTriggerExit2D(Collider2D collider){
    //     if(collider.gameObject.tag == "Player"){
    //         exitMenu();
    //     }
    // }


}
