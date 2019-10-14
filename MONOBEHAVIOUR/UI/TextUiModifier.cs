using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextUiModifier : MonoBehaviour
{
	private GameSettings gameSettings;
	[Header ("Display selector")]
	public bool isHP;
	public bool isCoins;
	public bool isWave;

	private TMPro.TextMeshProUGUI text;
	private void Start() {
		text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
	}

	private void Update()
    {
		if (isHP) {
			text.text = gameSettings.gameHealth.ToString();
		} else if (isCoins) {
			text.text = gameSettings.MapMoney.ToString();
		}else if (isWave) {
			//text.text = gameSettings.MapMoney.ToString();
		}
    }



}
