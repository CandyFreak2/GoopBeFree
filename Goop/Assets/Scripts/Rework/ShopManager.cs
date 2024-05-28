using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Ability = GoopAbilities.Ability;

public class ShopManager : MonoBehaviour {
    public List<Tuple<Ability, int, int>> shopItems = new(); // <Items/Ability, Cost, Quantity>
    private float points;
    public TextMeshProUGUI pointsText;

    void Start() {
        shopItems.Add(Tuple.Create(Ability.WINGS, 100, 1));
        shopItems.Add(Tuple.Create(Ability.FREEZE, 200, 1));
        shopItems.Add(Tuple.Create(Ability.WHIP, 300, 1));
    }

    void Update() {
        points = PlayerPrefs.GetInt("Points");
        pointsText.text = "Goop Points: " + points.ToString();
    }

    public void Buy() {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if (button != null) {
            if (button.TryGetComponent<ShopButton>(out var itemButton)) {
                Ability selectedAbility = itemButton.itemID;
                var shopItemIndex = shopItems.FindIndex(item => item.Item1 == selectedAbility);

                if (shopItemIndex != -1) {
                    var shopItem = shopItems[shopItemIndex];
                    int itemCost = shopItem.Item2;
                    int itemQuantity = shopItem.Item3;

                    if (itemQuantity > 0) {
                        if (points >= itemCost) {
                            points -= itemCost;
                            PlayerPrefs.SetInt("Points", (int)points);
                            pointsText.text = "Goop Points: " + points.ToString();

                            shopItems[shopItemIndex] = Tuple.Create(shopItem.Item1, shopItem.Item2, shopItem.Item3 - 1);

                            Debug.Log("Item bought: " + selectedAbility.ToString());
                        } else {
                            Debug.Log("Not enough points to buy: " + selectedAbility.ToString());
                        }
                    } else {
                        Debug.Log("Item out of stock: " + selectedAbility.ToString());
                    }
                } else {
                    Debug.Log("Shop item not found for ability: " + selectedAbility.ToString());
                }
            }
        }
    }
}
