using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public enum type{ Basic,Fire,Water,Earth,Lightning};
	[Header("Required Attributes")]
	public int value;
	public int health;
	public int enemyDamage;
	public float speed;
	public type EnemyType;

	[Header("Is Game Paused")]
	public GameSettings gameSettings;

	//private variables
	private int currentWaypoint = 0;
	private int numOfWaypoints;
    private Pathfinder path;
    private Transform nextWaypoint;
	private Transform[] pathArray;

	//Slow down attributes
	private bool slowDownBool = false;
	private float timeToSlowDown;
	private float slowDownAmount;
	private float originalSpeed;

    protected virtual void Start()
    {
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
		originalSpeed = speed;
		enemyDamage += gameSettings.difficulty;
		speed += gameSettings.difficulty;
		
		findPath();
    }

	private void Update()
    {
		if (!gameSettings.isPaused) {
			move();
		}
    }


	public void TakeDamage(int damage) {
		health -= damage;
		if (health <= 0) {
			gameSettings.MapMoney += value;
			Destroy(gameObject);
		}
	}

	#region Add Enemy to tower radius
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Tower")) {
			collision.GetComponent<TowerBase>().enemyList.Add(gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.CompareTag("Tower")) {
			collision.GetComponent<TowerBase>().enemyList.Remove(gameObject);
		}
	}
	#endregion

	#region Path and move functions
    public void move() {
		GetPosition(); //updates waypoint
            transform.position = 
			Vector2.MoveTowards(
				gameObject.transform.position, 
				nextWaypoint.position, 
				speed * Time.deltaTime * gameSettings.gameSpeed
				);
    }
	private void findPath() { //Called once on instantiation of Enemy
		path = gameObject.GetComponentInParent<Pathfinder>();
		numOfWaypoints = path.waypoints.Length;
		pathArray = path.waypoints;
		nextWaypoint = pathArray[0];
		if(path == null || numOfWaypoints == 0) {
			print("Spawner parent does not have <Pathfinder>");
		}
	}
	private void GetPosition() {
		float distance = Vector2.Distance(gameObject.transform.position,nextWaypoint.position);
		if (distance < .1f) {
			StartCoroutine(getNextWaypoint());
		}
	}
	IEnumerator getNextWaypoint() {
		currentWaypoint++;
		if (currentWaypoint >= numOfWaypoints) {
			gameSettings.takeDamage(enemyDamage);
			Destroy(gameObject);
		} else {
			nextWaypoint = pathArray[currentWaypoint];
		}
		yield return new WaitForSeconds(1/gameSettings.gameSpeed);	
	}
	#endregion

	#region SlowDown
	private void FixedUpdate() {
		if (Time.time <= timeToSlowDown) {
			SlowDown();
		} else {
			slowDownBool = false;
			speed = originalSpeed * gameSettings.gameSpeed;
		}
	}
	public void StartSlowDownEvent(float secondsToSlowDown, float amountToSlowdown) {
		float slowDownTime = secondsToSlowDown;
		slowDownAmount = amountToSlowdown;

		timeToSlowDown = Time.time + slowDownTime;
	}

	private void SlowDown() {
		if (!slowDownBool) {
			speed = (originalSpeed / 100) * (100 - slowDownAmount);
			speed *= gameSettings.gameSpeed;
			slowDownBool = true;
		}
	}
	#endregion
}
