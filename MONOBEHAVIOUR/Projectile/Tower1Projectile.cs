using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1Projectile : ProjectileBase
{
	private int damage;
    protected override void Start()
    {
		base.Start();
    }

    void Update()
    {
		if (!gameSettings.isPaused) {
			MoveToEnemy();
		}
    }
	private bool hit = false;
	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Enemy") && !hit) {
			hit = true;
			damage = parent.damage;
			collision.gameObject.GetComponent<EnemyMove>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}


}
