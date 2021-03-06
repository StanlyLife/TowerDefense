﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
	[Header ("Insert in inspector")]
	public GameSettings gameSettings;

	[Header("DEBUGS")]
	[SerializeField]
	protected float speed;
	private Vector3 lastPos;
	protected TowerBase parent;

	private void Awake() {
		FindGameObjects();
	}
	protected virtual void Start() {
		Destroy(gameObject, parent.projectileLife);
		speed *= gameSettings.gameSpeed;
	}
	private void FindGameObjects() {
		if (gameSettings == null) {
			gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
		}
		if (parent == null) {
			parent = gameObject.GetComponentInParent<TowerBase>();
		}
		speed = parent.projectileSpeed;
	}


	public void MoveToEnemy() {
		if (transform.position == lastPos) {
			Destroy(gameObject);
		}

		lastPos = transform.position;
		//transform.position = Vector2.Lerp(transform.position, target,speed*Time.deltaTime);
		//Makes projectile slowdown and stick
		//transform.position = Vector2.MoveTowards(transform.position, target,speed*Time.deltaTime);
		transform.Translate(Vector2.up * Time.deltaTime * speed * gameSettings.gameSpeed);
		//transform.Translate(Vector2.down * speed * Time.deltaTime * gameSettings.gameSpeed);
	}
}
