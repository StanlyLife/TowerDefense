using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	[Header ("Insert in inspector")]
	public GameSettings gameSettings;
	public Waves wavesObject;
	[Header ("Number of spawners")]
	public Spawner[] spawnerArray;
	[Header("Debugs")]
	public Waves.WaveDifficulty[] difficulty;
	[HideInInspector]
	public float timeBetweenSpawns;

	private Waves.WaveDifficulty waveDifficulty;
	private Waves.Wave currentWave;

	private int numOfWaves;
	private int numOfEnemiesToSpawn;

	private int currentWaveNumber;

	public bool isDoneSpawning;

	private int numberOfSpawners;

	public void Start() {
		setAttributes();
	}
	private int[] RegulateEnemySpawn() {

		#region create new enemiesToSpawn[] incase multiple spawners
		int[] newNumberOfEnemies = new int[currentWave.numberOfEnemies.Length];


		int numOfEnemiesIndex = 0;
		foreach(int i in currentWave.numberOfEnemies) {
			newNumberOfEnemies[numOfEnemiesIndex] = Mathf.RoundToInt(i/ spawnerArray.Length);
			numOfEnemiesIndex++;
		}

		#endregion
		return newNumberOfEnemies;
	}
	public void StartNextWave() {
		setAttributes();
		isDoneSpawning = false;
		#region number of enemies this wave
		numOfEnemiesToSpawn = 0;
		foreach(int i in currentWave.numberOfEnemies) {
			numOfEnemiesToSpawn += i;
		}
		#endregion
		print("Enemies this wave: " + numOfEnemiesToSpawn);


		int[] EnemiesThisWaveArray = RegulateEnemySpawn();
		foreach (Spawner currentSpawner in spawnerArray) { 
			currentSpawner.enemyArray = currentWave.enemies;
			currentSpawner.timeBetweenSpawns= currentWave.timeBetweenEnemies;
			currentSpawner.enemySpawnAmount = EnemiesThisWaveArray;

			currentSpawner.startWave();
		}
		isDoneSpawning = true;
		currentWaveNumber++;
	}

	private void setAttributes() {
		try {

			waveDifficulty = difficulty[gameSettings.difficulty];
			currentWave = waveDifficulty.WaveNumber[currentWaveNumber /*wave number*/];
			numOfWaves = waveDifficulty.WaveNumber.Length;
			timeBetweenSpawns = 0;
			foreach (float time in currentWave.timeBetweenEnemies) {
				if (time > timeBetweenSpawns) {
					timeBetweenSpawns = time;
					//timebetweenspawns IS longest enemy wait time this wave
				}
			}

		}catch (System.Exception e) when (e is System.IndexOutOfRangeException) {
			print("WaveSpawner has no more waves");
		}
	}

}
