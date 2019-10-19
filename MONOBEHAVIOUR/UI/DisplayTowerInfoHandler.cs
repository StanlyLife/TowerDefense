using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayTowerInfoHandler : MonoBehaviour
{
	/*Variables*/
	public TowerInfoHandler TIH;
	private int towerID;
	private int clickCount;
	private bool hover = false;
	/*Methods*/
	public void Update() {
		if (hover) {
			if (Input.GetMouseButtonDown(1) && clickCount <= 0) {
				TIH.SetText(towerID);
			}
		}else {
			clickCount = 0;
		}
	}
	public void OnHoverEnter(int TowerID) {
		hover = true;
		towerID = TowerID;
	}
	public void OnHoverExit() {
		hover = false;
	}
}
