using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : ProjectileBase
{
	[SerializeField]
	private GameObject cannonExplotion;
	private Vector3 lastPosition;
	private Vector2 target;

	protected override void Start() {
		Destroy(gameObject,gameObject.GetComponentInParent<TowerBase>().projectileLife);
		base.Start();
		print("Im here");
		target = gameObject.GetComponentInParent<CannonTower>().enemyInFocus.transform.position;
	}

	private void Update() {
		if (!gameSettings.isPaused) {
			MoveToEnemy();
		}
	}

	private void OnDestroy() {
			Instantiate(cannonExplotion,transform.position,new Quaternion(),gameObject.GetComponentInParent<Transform>());
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag("Enemy")) {
			StartCoroutine(waitToDestroy());
		}
	}

	IEnumerator waitToDestroy() {
		yield return new WaitForSeconds(.05f/gameSettings.gameSpeed);
		Destroy(gameObject);
	}



}
