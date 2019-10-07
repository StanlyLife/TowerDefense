using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextUiModifier : MonoBehaviour
{
	public GameSettings gameSettings;

	public bool isHP;
	public bool isCoins;

	public TMPro.TextMeshProUGUI text;
	private void Start() {
		text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
	}

	void Update()
    {
		if (isHP) {
			text.text = gameSettings.gameHealth.ToString();
		} else if (isCoins) {
			text.text = gameSettings.MapMoney.ToString();
		}
    }



}
