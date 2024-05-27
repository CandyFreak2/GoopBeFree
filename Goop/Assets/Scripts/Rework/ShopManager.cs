using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Ability = GoopAbilities.Ability;


public class ShopManager : MonoBehaviour
{
    public List<Tuple<Ability, int>> shopItems = new(); // <Items/Ability, Cost>
    private float points;
    public TextMeshProUGUI pointsText;

    void Start() {
        shopItems.Add(Tuple.Create(Ability.WINGS, 100));
        shopItems.Add(Tuple.Create(Ability.FREEZE, 200));
        shopItems.Add(Tuple.Create(Ability.WHIP, 300));
    }

    // Update is called once per frame
    void Update()
    {
        points = PlayerPrefs.GetInt("Points");
        pointsText.text = "Goop Points: " + points.ToString();
    }

    public void Buy() {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if (button != null) {
            
            if (button.TryGetComponent<ShopButton>(out var itemButton)) {
                Ability selectedAbility = itemButton.itemID;
                var shopItem = shopItems.Find(item => item.Item1 == selectedAbility);

                if (shopItem != null) {
                    int itemCost = shopItem.Item2;
                    if (points >= itemCost) {
                        points -= itemCost;
                        PlayerPrefs.SetInt("Points", (int)points);
                        pointsText.text = "Goop Points: " + points.ToString();
                        Debug.Log("Item bought: " + selectedAbility.ToString());
                    } else {
                        Debug.Log("Not enough points to buy: " + selectedAbility.ToString());
                    }
                } else {
                    Debug.Log("Shop item not found for ability: " + selectedAbility.ToString());
                }
            }
        }
    }

}
