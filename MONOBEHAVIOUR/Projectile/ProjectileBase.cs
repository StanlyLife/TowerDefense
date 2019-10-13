using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
	public GameSettings gameSettings;
	public Tower1 parent;
	[Header("DEBUGS")]
	[SerializeField]
	private float speed;
	//private Vector2 target;
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
			parent = gameObject.GetComponentInParent<Tower1>();
		}
		speed = parent.projectileSpeed;

	}


	public void MoveToEnemy() {
		//speed *= globalVariables.gameSpeed;
		if (transform.position == lastPos) {
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
