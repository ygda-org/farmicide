using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    public enum ItemType{
        //insert item names here
        yourMom
    }

    public static int GetCost(ItemType itTy){ 
        switch(itTy){ //looks at itemtype and switches it with given value
            default:
            case ItemType.yourMom: return 0;
        }
    }
    
    /* first need to set up GameAsset script to pull sprites and also need sprite

    public static Sprite getSprite(ItemType itTy){
        switch(itTy){ //looks at itemtype and switches it with given sprite

        }
    }
    */
}
