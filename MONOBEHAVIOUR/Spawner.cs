using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //EnemyList
    //WaveList
    public float timeBetweenSpawns;
    private float spawnTimer;
	public GameSettings gameSettings;
    public GameObject enemy;

    public void Awake() {
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
		spawnTimer = timeBetweenSpawns;
    }
    public void Update() {

		spawn(enemy);
    }

	private void spawn(GameObject enemyType) {
        if (Time.time >= spawnTimer && !gameSettings.isPaused) {
            Instantiate(enemyType,transform);
            spawnTimer = Time.time + (timeBetweenSpawns/gameSettings.gameSpeed);
        }

	}

}
