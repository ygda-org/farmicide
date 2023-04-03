using TMPro;
using UnityEngine;

public class ShopItemHandler : MonoBehaviour
{
    public TextMeshProUGUI costText;
    public TextMeshProUGUI nameText;
    public SpriteRenderer selectedBackground;

    public void setCostText(int cost){
        costText.text = "$ " + cost;
    }
    public void setNameText(string itemName){
        nameText.text = itemName;
    }
    public void select(){
        selectedBackground.enabled = true;
    }
    public void deselect(){
        selectedBackground.enabled = false;
    }
}
