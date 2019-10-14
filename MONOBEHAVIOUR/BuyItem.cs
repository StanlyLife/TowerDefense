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

	public void buyTower7() { //cannon
		if (store.buy("tower7")) {
			cursor.Hold(towerCollection.Towers[6].DummyTower.gameObject, towerCollection.Towers[6].RealTower.gameObject);
		}
	}

	public void buyTower8() { //cannon
		if (store.buy("tower8")) {
			cursor.Hold(towerCollection.Towers[7].DummyTower.gameObject, towerCollection.Towers[7].RealTower.gameObject);
		}
	}
	public void buyTower9() { //cannon
		if (store.buy("tower9")) {
			cursor.Hold(towerCollection.Towers[8].DummyTower.gameObject, towerCollection.Towers[8].RealTower.gameObject);
		}
	}
	public void buyTower10() { //cannon
		if (store.buy("tower10")) {
			cursor.Hold(towerCollection.Towers[9].DummyTower.gameObject, towerCollection.Towers[9].RealTower.gameObject);
		}
	}

	//I know this is a very bad example of reusing code, but the project is closing to an end and i cba with this demo...
}
