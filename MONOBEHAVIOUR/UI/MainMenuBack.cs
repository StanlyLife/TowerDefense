using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBack : MonoBehaviour
{
	private bool isHTPCanvas;
	private bool isAboutCanvas;

	public GameObject aboutCanvas;
	public GameObject HTPCanvas;
	
	public void setCanvas(string type) {
		if(type.ToLower() == "about") {
			isHTPCanvas = false;
			isAboutCanvas = true;
		}else if (type.ToLower() == "htp") {
			isAboutCanvas = false;
			isHTPCanvas = true;
		}
		openCanvas();
	}

	public void back() {
		aboutCanvas.SetActive(false);
		HTPCanvas.SetActive(false);
	}

	public void openCanvas() {
		if (isHTPCanvas) {
			back();
			HTPCanvas.SetActive(true);
		} else if(isAboutCanvas) {
			back();
			aboutCanvas.SetActive(true);
		}
	}
}
