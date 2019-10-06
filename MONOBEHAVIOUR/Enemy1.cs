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
}
