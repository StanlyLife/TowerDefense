using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : TowerBase
{
	[Header ("Radius of tower")]
	public float radius;
	[Header ("How much to slow down")]
	[Range(0,100)]
	public float percentToSlowDown;
	[Header ("Time before normal")]
	public float timeSlowed;
	private Animator anim;
	[SerializeField]
	private Collider2D[] enemies;
	public override void Start() {
		base.Start();
		anim = GetComponent<Animator>();
	}

	private void Update() {
		if (!gameSettings.isPaused) {
			Fire();
		}
	}

	private void Fire() {
		if (Time.time >= lastProjectileTime && enemyList.Count >= 1 || lastProjectileTime > Mathf.Pow(10, 10)) {
			lastProjectileTime = Time.time + (timeBetweenProjectiles / gameSettings.gameSpeed);
			anim.SetTrigger("SlowEnemies");

			enemies = Physics2D.OverlapCircleAll(transform.position, radius);

			foreach(Collider2D enemy in enemies) {
				if (enemy.CompareTag("Enemy")) {
					enemy.gameObject.GetComponent<EnemyMove>().SlowDown(percentToSlowDown,timeSlowed);
				}
			}
		}
	}

}
