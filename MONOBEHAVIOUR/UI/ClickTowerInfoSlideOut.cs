using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTowerInfoSlideOut : MonoBehaviour
{
	private TowerInfoHandler TIH;
    void Start()
    {
		TIH = GetComponent<DisplayTowerInfoHandler>().TIH;
    }

	private void Update() {
		if (Input.GetMouseButtonDown(0) && TIH.isActive) {
			TIH.Slide("Out");
		}
	}

}
