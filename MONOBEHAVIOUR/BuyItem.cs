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
            cursor.Hold(towerCollection.Towers[0].DummyTower.gameObject , towerCollection.Towers[0].RealTower.gameObject);
        }
    }
	public void buyTower2() {
        if (store.buy("tower2")) {
            cursor.Hold(towerCollection.Towers[1].DummyTower.gameObject , towerCollection.Towers[1].RealTower.gameObject);
        }
    }
}
