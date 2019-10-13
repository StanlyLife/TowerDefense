using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuyItem : MonoBehaviour
{
    public Store store;
    public PlaceItem cursor;
    public TowerCollection towerCollection;
    
    public void buyTower1() {
        if (store.buy("tower1")) { //normal tower
            cursor.Hold(towerCollection.Towers[0].DummyTower.gameObject , towerCollection.Towers[0].RealTower.gameObject);
        }
    }
	public void buyTower2() {
        if (store.buy("tower2")) { //laser tower sniper
            cursor.Hold(towerCollection.Towers[1].DummyTower.gameObject , towerCollection.Towers[1].RealTower.gameObject);
        }
    }
	public void buyTower3() {
        if (store.buy("tower3")) { //stone shooter
            cursor.Hold(towerCollection.Towers[2].DummyTower.gameObject , towerCollection.Towers[2].RealTower.gameObject);
        }
    }

	public void buyTower4() { //cannon
		if (store.buy("tower4")) {
			cursor.Hold(towerCollection.Towers[3].DummyTower.gameObject, towerCollection.Towers[3].RealTower.gameObject);
		}
	}

}
