using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "TowerCollectionSO",menuName = "ScriptableObject/TowerCollection")]
public class TowerSoCollection : ScriptableObject
{
	[System.Serializable]
	public class TowerCollectionClass {
		public string name;
		[Header("Insert in inspector")]
		public Tower _Tower;
		[Space (10)]
		public Sprite towerImage;
		public Sprite ProjectileImage;
		[Header ("Leave empty")]
		public int ID;
		[HideInInspector]
		public int price;
		[HideInInspector]
		public int sellPrice;
		[HideInInspector]
		public string description;
	}

	public TowerCollectionClass[] Towers;

	void OnEnable() {
		for(int i = 0; i < Towers.Length; i++) {
			try {
				Towers[i].name = Towers[i]._Tower.TowerName;
				Towers[i].ID = Towers[i]._Tower.towerID;
				Towers[i].sellPrice = Towers[i]._Tower.sellPrice;
				Towers[i].price = Towers[i]._Tower.storePrice;
			}catch (System.Exception e) when (e is System.NullReferenceException) {
				//That array item is not created yet
			}
		}

	}
}
