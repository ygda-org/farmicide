using UnityEngine;
using TMPro;
public class ShopItemData : MonoBehaviour
{
    public TextMeshProUGUI costText;
    public int cost;
    public int Cost {
        get {
            return cost;
        }
        set {
            cost = value;
            costText.text = "$ " + cost;
        }
    }


    public TextMeshProUGUI nameText;

    public string Name { 
        get {
            return nameText.text;
        }

        set {
            nameText.text = value;
        }
    }
}
