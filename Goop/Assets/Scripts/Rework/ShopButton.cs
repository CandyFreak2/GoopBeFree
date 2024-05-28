using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour {
    public GoopAbilities.Ability itemID;
    public TextMeshProUGUI priceText, quantityText;
    private ShopManager shopManager;

    void Start() {
        shopManager = GameObject.Find("EventSystem").GetComponent<ShopManager>();
    }

    void Update() {
        var shopItem = shopManager.shopItems.Find(item => item.Item1 == itemID);
        if (shopItem != null) {
            int itemCost = shopItem.Item2;
            int itemQuantity = shopItem.Item3;
            priceText.text = "Price: " + itemCost.ToString();
            quantityText.text = "Quantity: " + itemQuantity.ToString(); 
        } else {
            priceText.text = "Price: N/A";
            quantityText.text = "Quantity: N/A";
        }
    }
}
