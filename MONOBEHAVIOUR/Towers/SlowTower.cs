using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : TowerBase
{
	[Range(0,100)]
	public float percentToSlowDown;
	[Header ("Time before normal")]
	public float timeSlowed;

	//private variables
	private Animator anim;
	public override void Start() {
		base.Start();
		anim = GetComponent<Animator>();
	}

	private void Update() {
		if (!gameSettings.isPaused) {
			Fire();
			anim.SetFloat("gamespeed", gameSettings.gameSpeed);
		} else {
			anim.SetFloat("gamespeed", 0);
		}
	}

	private void Fire() {
		if (Time.time >= lastProjectileTime && enemyList.Count >= 1 || lastProjectileTime > Mathf.Pow(10, 10)) {
			lastProjectileTime = Time.time + (timeBetweenProjectiles / gameSettings.gameSpeed);
			anim.SetTrigger("SlowEnemies");

			foreach(GameObject enemy in enemyList) {
				enemy.GetComponent<EnemyMove>().StartSlowDownEvent(timeSlowed, percentToSlowDown);
			}
		}
	}

}
