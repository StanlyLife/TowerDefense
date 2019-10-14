using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : TowerBase
{
	[HideInInspector]
	public GameObject enemyInFocus;

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
		if (!gameSettings.isPaused) {
            FollowEnemy();
		}
    }
	public void FollowEnemy() {
		if (enemyList.Count > 0) {
			if (targetPriority == target.first) {
				enemyInFocus = GetEnemyInFocus(target.first);
			} else if (targetPriority == target.last) {
				enemyInFocus = GetEnemyInFocus(target.last);
			}
			if(enemyInFocus != null) {
				lookAt(enemyInFocus);
				fire();
			}
		}
	}

	private GameObject GetEnemyInFocus(target x) {
		try {

		switch (x) {
			case target.first: //get first target
				foreach (GameObject enemy in enemyList) {
						if(enemy != null) {
							return enemy;
						} else {
							enemyList.Remove(enemy);
						}
				}return null;

			case target.last: //get last target
				for(int i = enemyList.Count-1; i >= 0; i--) {
					if(enemyList[i] != null) {
						return enemyList[i];
					} else {
						enemyList.RemoveAt(i);
					}
				}return null;


			case target.strong:
				//placeholder
				return enemyList[0];
			case target.weak:
				//placeholder
				return enemyList[0];
			default:
				//placeholder
				return enemyList[0];
		}
		}catch(System.Exception e) {
			if(e is System.InvalidOperationException) {
				return null;
			} else {
				Debug.Log("ERROR in GetEnemyInFocus() Tower1: " + e);
				Destroy(gameObject);
				return null;
			}
		}
	}

	public void fire() {
		if (enemyInFocus!=null) {

			#region Rotate projectiles relative to head
			Vector2 dir = enemyInFocus.transform.position - headHolder.transform.position;
			//float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + normaliseRotationBy;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
			#endregion

			if (Time.time >= lastProjectileTime || lastProjectileTime > Mathf.Pow(10,10)) {
				lastProjectileTime = Time.time + (timeBetweenProjectiles/gameSettings.gameSpeed);
				
				//Instantiate(GoProjectile, headHolder.transform.position, headHolder.transform.rotation,transform /*parent*/);
				Instantiate(GoProjectile, headHolder.transform.position, rotation,transform /*parent*/);
				//Instantiate(GoProjectile, headHolder.transform);
			}
		}
	}
}
