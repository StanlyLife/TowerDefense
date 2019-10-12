using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
	public GameSettings gameSettings;
	public TowerBase parent;
	[Header("DEBUGS")]
	[SerializeField]
	private float speed;
	private Vector2 target;
	private Vector3 lastPos;

	private void Awake() {
		FindGameObjects();
	}
	protected virtual void Start() {
		Destroy(gameObject, parent.projectileLife);
	}

	private void FindGameObjects() {
		if (gameSettings == null) {
			gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
		}
		if (parent == null) {
			parent = gameObject.GetComponentInParent<TowerBase>();
		}
		speed = parent.projectileSpeed;
		//target = parent2.enemyInFocus.transform.position;

	}


	public void MoveToEnemy() {
		//speed *= globalVariables.gameSpeed;
		if (target == null || transform.position == lastPos) {
			Destroy(gameObject);
		}

		lastPos = transform.position;
		//transform.position = Vector2.Lerp(transform.position, target,speed*Time.deltaTime);
		//Makes projectile slowdown and stick
		//transform.position = Vector2.MoveTowards(transform.position, target,speed*Time.deltaTime);
		transform.Translate(Vector2.one * Time.deltaTime * speed * gameSettings.gameSpeed);
		transform.Translate(Vector2.down * speed * Time.deltaTime * gameSettings.gameSpeed);
	}
}
