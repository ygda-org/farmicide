using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShopScript : MonoBehaviour
{
    public Collider2D shopTrigger;

    public GameObject shopUIContainer; 
    public GameObject shopItemPrefab;
    
    public float shopItemSpacing;

    public Vector2 defaultShopUIPosition; // unused currently



    private void Awake(){;
        // shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start(){
        createItemButton("e", Items.GetCost(Items.ItemType.yourMom), 0);
        createItemButton("F", Items.GetCost(Items.ItemType.yourMom), 1);
        hide();
        
    }
    private void createItemButton(string itemName, int itemCost, int positionIndex){ //add sprite param later
        GameObject shopItem = Instantiate(shopItemPrefab, shopUIContainer.transform);
        shopItem.transform.parent = shopUIContainer.transform;

        // RectTransform shopItemRectTransform = shopItem.GetComponent<RectTransform>();

        ShopItemData itemData  = shopItem.GetComponent<ShopItemData>();

        float shopItemHeight = 15f;
        
        shopItem.transform.position = shopItem.transform.position + new Vector3(0, - shopItemHeight * positionIndex * 0.1f, 0);  //change the float multiplier if ui design is changed

        itemData.Cost = itemCost;
        itemData.Name = itemName;
    }

    public void hide(){
        shopUIContainer.SetActive(false);
    }

    public void show(){
        shopUIContainer.SetActive(true);
    }



    // activate shop
    private void OnTriggerEnter2D(Collider2D collider){
            if(collider.gameObject.tag == "Player"){
                show();
            }
    }
    
    private void OnTriggerExit2D(Collider2D collider){
            if(collider.gameObject.tag == "Player"){
                hide();
            }
    }


}
