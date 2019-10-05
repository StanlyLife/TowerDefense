using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
	[Header("Sound settings")]
	public float masterLevel;
	public float soundLevel;
	public float musicLevel;

	[Header("Game Settings")]
	//speed x3, speed x1
	public float gameSpeed = 1;
	[Tooltip("Is game paused, true false")] public bool isPaused = false;
	[Header("Game attributes")]
	public int gameHealth;
	public int MapMoney;

	public void takeDamage(int damage) {
		gameHealth -= damage;
	}
}
