using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Store", menuName = "ScriptableObject/Store")]
public class Store : ScriptableObject
{
    [Header("Inventory for money and such")]
    public Inventory inventory;
    [Header("Store tower prices")]
    public int tower1;
    public int tower2;
    public int tower3;
    public int tower4;
	public int tower5;
    public int tower6;
    public int tower7;
    public int tower8;
    public int tower9;
    public int tower10;
	public int tower11;
    public int tower12;

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
			case "tower5":
            price = tower5;
            break;
			case "tower6":
            price = tower6;
            break;
			case "tower7":
			price = tower7;
			break;
			case "tower8":
			price = tower8;
			break;
			case "tower9":
			price = tower9;
			break;
			case "tower10":
			price = tower10;
			break;
			case "tower11":
			price = tower11;
			break;
			case "tower12":
			price = tower12;
			break;

			default:
				//No tower instance
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
