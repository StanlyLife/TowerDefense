using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour {
	[Header("WaveSpawner")]
	[SerializeField]
	private WaveSpawner wave;

	#region unique settings each game
	[Header("Game Settings")]

	[Tooltip("1 by default")]
	public float gameSpeed = 1;

	[Tooltip("0 by defaut, easy")]
	public int difficulty = 0; //0 easy, 1 medium, 2 hard, 3 impossible

	public int gameHealth;
	public int MapMoney;

	public bool isPaused = false;

	[Tooltip("game settings own attribute, is spawning done, forces wave")]
	public bool gameSettingsWaveDone = false;
	#endregion

	#region sound settings
	[Header("Sound settings")]
	[Range (0,100)]
	public float masterLevel;
	[Range (0,100)]
	public float soundLevel;
	[Range (0,100)]
	public float musicLevel;
	#endregion



	#region wave info
	[Header("NextWave button")]
	public Button StartButton;

	[HideInInspector]
	public int enemiesAmount;

	[HideInInspector]
	public bool[] doneSpawning;

	[HideInInspector]
	public int currentWave = 0;
	#endregion

	#region death screen info
	[Header("Death transition panel")]
	public GameObject deadTransition;
	public DeadTransition deadScreen;
	#endregion

	private bool allDoneSpawning;
	private bool waveStart = false;
	
	private void FixedUpdate() {
		if (waveStart) {
			StartButton.interactable = false;
			foreach(bool spawner in doneSpawning) {
				if (spawner) {
					allDoneSpawning = true;
				} else {
					allDoneSpawning = false;
					break;
				}
			}

			if (enemiesAmount <= 0 && allDoneSpawning) {
				StartCoroutine(isWaveDone());
			}
		}
	}


	 IEnumerator isWaveDone() {
		yield return new WaitForSeconds(wave.timeBetweenSpawns);
		if (enemiesAmount <= 0) {
			enemiesAmount = 0;
			waveStart = false;
			isPaused = true;
			gameSpeed = 1;
			StartButton.interactable = true;
			//Activate button
		}

	}


	private void Start() {
		//Activate button
		doneSpawning = new bool[wave.spawnerArray.Length];
		isPaused = false;
		gameSpeed = 1;
	}

	public void StarNexttWave() {
		//Deactivatebutton
		currentWave++;
		waveStart = true;
		isPaused = false;
		wave.StartNextWave();
	}

	public void SetGameSpeed(int speed) {
		//Divided by 10 as the button in inspector does not accept a float
		gameSpeed = speed/10;
	}

	private enum difficultyEnum {
		easy = 0,
		medium = 1,
		hard = 2,
		impossible = 3
	}

	public void takeDamage(int damage) {
		gameHealth -= damage;
		if (gameHealth <= 0) {
			deadTransition.SetActive(true);
			isPaused = true;
			gameSpeed = 0;
			deadScreen.PlayAnimation();
		}
	}
}
