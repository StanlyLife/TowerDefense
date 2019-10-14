using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonExplosion : MonoBehaviour
{
	public GameSettings gameSettings;
	private Animator animation;

	private float radius;
	private int projectileDamage;
	private CannonTower cannonParent;
    void Start()
    {
		animation = gameObject.GetComponent<Animator>();
		animation.SetFloat("gamespeed", gameSettings.gameSpeed);
		cannonParent = gameObject.GetComponentInParent<CannonTower>();
		projectileDamage = cannonParent.damage;

		DamageEnemies();
    }

	private void DamageEnemies() {
		radius = cannonParent.explosionRadius;
		Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position,radius);

		foreach(Collider2D collisions in enemiesInRange) {
			if (collisions.CompareTag("Enemy")) {
				collisions.gameObject.GetComponent<EnemyMove>().TakeDamage(projectileDamage);
			}
		}

		Destroy(gameObject,.2f*gameSettings.gameSpeed);
	}
}
