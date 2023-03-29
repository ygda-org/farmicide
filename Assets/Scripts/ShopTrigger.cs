using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    
    public UIShopScript UIShop; 

    private void OnTriggerEnter2D(Collider2D collider){
            if(collider.gameObject.tag == "Player"){
                UIShop.show();
            }
    }
    
    private void OnTriggerExit2D(Collider2D collider){
            if(collider.gameObject.tag == "Player"){
                UIShop.hide();
            }
    }
}
