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
	public void buyTower5() { //cannon
		if (store.buy("tower5")) {
			cursor.Hold(towerCollection.Towers[4].DummyTower.gameObject, towerCollection.Towers[4].RealTower.gameObject);
		}
	}
	public void buyTower6() { //cannon
		if (store.buy("tower6")) {
			cursor.Hold(towerCollection.Towers[5].DummyTower.gameObject, towerCollection.Towers[5].RealTower.gameObject);
		}
	}

	//I know this is a very bad example of reusing code, but the project is closing to an end and i cba with this demo...
}
