using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
	public GameSettings gameSettings;
	private Tower1 parent;
	[Header ("DEBUGS")]
	[SerializeField]
	private float speed;
	private Vector2 target;
	private Vector3 lastPos;
    void Start()
    {
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
		parent = gameObject.GetComponentInParent<Tower1>();
		speed = parent.projectileSpeed;
		target = parent.enemyInFocus.transform.position;
		Destroy(gameObject,parent.projectileLife);
    }

    void Update()
    {
		if (!gameSettings.isPaused) {
			MoveToEnemy();
		}
    }

	private void MoveToEnemy() {
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

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Enemy") {
			//takeDamage from enemy;
			Destroy(gameObject);
		}
	}
}
