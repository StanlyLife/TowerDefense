using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuyItem : MonoBehaviour
{
    public PlaceItem cursor;
    public TowerCollection towerCollection;
	public TowerSoCollection tso;
	public GameSettings gs;


	public void buy(int id) {
		TowerSoCollection.TowerCollectionClass tower = GetTowerCollection(id);
		if(tower.price <= gs.MapMoney && tower._Tower.storePrice <= gs.MapMoney) {
            cursor.Hold(towerCollection.Towers[id-101].DummyTower.gameObject , towerCollection.Towers[id-101].RealTower.gameObject);
		} else {
			print("Not enough money");
			print("Mapmoney: " + gs.MapMoney);
			print("price: " + tower.price);
			//Display You do not hace enough money
		}
	}

	private TowerSoCollection.TowerCollectionClass GetTowerCollection(int id) {
		foreach (TowerSoCollection.TowerCollectionClass tc in tso.Towers) {
			if (tc.ID == id) {
				return tc;
			}
		}
		print("Did not find any class with that ID");
		return null;
	}

	//I know this is a very bad example of reusing code, but the project is closing to an end and i cba with this demo...
}
