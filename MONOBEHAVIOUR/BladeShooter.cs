using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeShooter : TowerBase
{
	[SerializeField]
	private Transform[] projectileHoles;
	private Animator anim;
	public override void Start() {
		base.Start();
		anim = GetComponent<Animator>();
	}
	void Update() {
		if (!gameSettings.isPaused) {
			fire();
			anim.SetFloat("gamespeed", gameSettings.gameSpeed);
		} else {
			anim.SetFloat("gamespeed", 0);
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
