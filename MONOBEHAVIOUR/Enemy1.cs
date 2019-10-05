using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyMove
{
    void Update()
    {
		if (!gameSettings.isPaused) {
			move();
		}
	}

	public void TakeDamage(int damage) {
		health -= damage;
		if (health >= 0) {
			Destroy(gameObject);
		}
	}

}
