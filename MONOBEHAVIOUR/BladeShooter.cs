using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeShooter : TowerBase
{
	[SerializeField]
	private Transform[] projectileHoles;
	
	public override void Start() {
		base.Start();
	}
	void Update() {
		if (!gameSettings.isPaused) {
			fire();
		}
	}
	public void fire() {
			if (Time.time >= lastProjectileTime && enemyList.Count >= 1 || lastProjectileTime > Mathf.Pow(10, 10)) {
				lastProjectileTime = Time.time + (timeBetweenProjectiles / gameSettings.gameSpeed);

				foreach (Transform transform in projectileHoles) {
					Instantiate(GoProjectile,transform);
				}
			}
	}
}
