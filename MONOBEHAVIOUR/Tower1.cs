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
				enemyInFocus = enemyList[0];
				lookAt(enemyList[0]);
			} else if (targetPriority == target.last) {
				enemyInFocus = enemyList[enemyList.Count - 1];
				lookAt(enemyList[enemyList.Count - 1]);
			}

			fire();
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
