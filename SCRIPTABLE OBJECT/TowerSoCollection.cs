using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "TowerCollectionSO",menuName = "ScriptableObject/TowerCollection")]
public class TowerSoCollection : ScriptableObject
{
	[System.Serializable]
	public class TowerCollectionClass {
		[Header ("Common Attributes")]
		public string name;
		public int ID;
		
		public Tower _Tower;

		[Header("Info")]
		public int price;
		public int sellPrice;
		[Space (10)]
		public Sprite towerImage;
		public Sprite ProjectileImage;
		[Space (10)]
		[Header("Description")]
		[Multiline]
		public string description;
	}

	public TowerCollectionClass[] Towers;

	public void OnEnable() {
		
		for(int i = 0; i < Towers.Length; i++) {
			Towers[i].name = Towers[i]._Tower.TowerName;
			Towers[i].ID = Towers[i]._Tower.towerID;
		}

	}
}
