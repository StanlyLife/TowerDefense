using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuyItem : MonoBehaviour
{
    public PlaceItem cursor;
    public TowerCollection towerCollection;
	public TowerSoCollection tso;
	public GameSettings gs;
	[SerializeField]
	private NemHandler notenoughmoney;

	public void buy(int id) {
		TowerSoCollection.TowerCollectionClass tower = GetTowerCollection(id);
		if(tower.price <= gs.MapMoney) {
            cursor.Hold(towerCollection.Towers[id-101].DummyTower.gameObject , towerCollection.Towers[id-101].RealTower.gameObject);
		} else {
			print("Not enough money");
			print("Money: " + gs.MapMoney);
			print("price: " + tower.price);
			notenoughmoney.playAnimation();
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
