using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	//EnemyList
	//WaveList
	[Header("Game Settings")]
	public GameSettings gameSettings;
	int spawnerNumber;
	[Header("Wave attributes")]
    public GameObject[] enemyArray;
	public int[] enemySpawnAmount;

    public float[] timeBetweenSpawns;


    private float spawnTimer;

    private void Awake() {
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
    }
	
	public void startWave() {
		if (enemyArray != null && enemySpawnAmount.Length == enemyArray.Length) {
			StartCoroutine(spawnEnemy(enemyArray, enemySpawnAmount, timeBetweenSpawns));
		} else {
			print("Spawner " + gameObject + " could not start wave because of conditions in Spawner.cs" );
			print(enemyArray);
			print("enemySpawnAmount length = " + enemySpawnAmount.Length);
			print("enemyArray.length = " + enemyArray.Length);
			
		}
	}


	IEnumerator spawnEnemy(GameObject[] enemyType, int[] amountToSpawn, float[] tbs) {

		gameSettings.doneSpawning[spawnerNumber] = false;
		int count = 0;
		foreach (GameObject enemy in enemyType) {
			for (int x = 1; x <= amountToSpawn[count];) {
				if (!gameSettings.gsWaveDone && !gameSettings.isPaused) {
					gameSettings.enemiesAmount++;
					Instantiate(enemy, gameObject.transform);
					x++;
					yield return new WaitForSeconds(tbs[count] * gameSettings.gameSpeed);
				} else {
					yield return new WaitForSeconds(1);
				}
			}
			count++;
		}
		gameSettings.doneSpawning[spawnerNumber] = true;
	}

}