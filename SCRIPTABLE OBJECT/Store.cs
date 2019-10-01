using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Store", menuName = "ScriptableObject: Store")]
public class Store : ScriptableObject
{
    [Header("Inventory for money and such")]
    public Inventory inventory;
    [Header("Store tower prices")]
    public int tower1;
    public int tower2;
    public int tower3;
    public int tower4;

    #region buy method
    public bool buy(string tower) {
        int price = 0;

        switch (tower.ToLower()) {
            case "tower1":
            price = tower1;
            break;
            case "tower2":
            price = tower2;
            break;
            case "tower3":
            price = tower3;
            break;
            case "tower4":
            price = tower4;
            break;

            default:
                return false;
        }



        if(inventory.MapMoney >= price) {
            inventory.MapMoney -= price;
            return true;
        }else {
            //Popup saying, you dont have enough money
            return false;
        }
    }
    #endregion

}
