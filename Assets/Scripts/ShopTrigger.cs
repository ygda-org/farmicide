using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    // Start is called before the first frame update
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
