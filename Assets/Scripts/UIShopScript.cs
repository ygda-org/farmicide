using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShopScript : MonoBehaviour
{

    public Collider2D shopTrigger;

    public GameObject shopUI;
    private GameObject container;
    private GameObject shopItemTemplate;


    private void Awake(){
        container = shopUI.transform.Find("container").gameObject;
        shopItemTemplate = container.transform.Find("shopItemTemplate").gameObject;
        // shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start(){
        createItemButton("e", Items.GetCost(Items.ItemType.yourMom), 0);
        createItemButton("F", Items.GetCost(Items.ItemType.yourMom), 1);
        shopItemTemplate.gameObject.SetActive(false);
        hide();
        
    }
    private void createItemButton(string itemName, int itemCost, int positionIndex){ //add sprite param later
        Transform shopItemTransform = Instantiate(shopItemTemplate.transform, container.transform);
        RectTransform shopItemRectTransform = shopItemTemplate.GetComponent<RectTransform>();
    
        float shopItemHeight = 30f;
        
        shopItemTransform.position = shopItemTransform.position + new Vector3(0, - shopItemHeight * positionIndex * 0.1f, 0);  //change the float multiplier if ui design is changed

        shopItemTransform.Find("cost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("name").GetComponent<TextMeshProUGUI>().SetText(itemName);
    }

    public void hide(){
        shopUI.SetActive(false);
    }

    public void show(){
        shopUI.SetActive(true);
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
