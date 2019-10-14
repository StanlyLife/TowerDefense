using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
	[Header("WaveSpawner")]
	public WaveSpawner wave;
	[Tooltip ("game settings own attribute, is spawning done, forces wave")]public bool gsWaveDone = false;
	[Header("Sound settings")]
	public float masterLevel;
	public float soundLevel;
	public float musicLevel;

	[Header("Game Settings")]
	[Tooltip ("1 by default")]
	public float gameSpeed = 1;
	[Tooltip ("0 by defaut, for easy")]
	public int difficulty = 0; //0 easy, 1 medium, 2 hard, 3 impossible
	[Tooltip("Is game paused, true false")]
	public bool isPaused = false;
	[Header("Game attributes")]
	public int gameHealth;
	public int MapMoney;



/* FIX THIS LATER!
	private void Update() {
		print(wave.numberOfSpawners);
		if (wave.isDoneSpawning && (spawnDone % wave.numberOfSpawners) == 1) {
			print("Wave Done");
			isPaused = true;
		}
	}
*/

	public void StarNexttWave() {
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
	}
}
