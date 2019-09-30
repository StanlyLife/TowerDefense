using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuyItem : MonoBehaviour
{
    public Store store;
    public PlaceItem cursor;
    public TowerCollection towerCollection;
    
    public void buyTower1() {
        if (store.buy("tower1")) {
            print("pressed Button");
            cursor.Hold(towerCollection.Towers[0].DummyTower.gameObject , towerCollection.Towers[0].RealTower.gameObject);
        }
    }
}
