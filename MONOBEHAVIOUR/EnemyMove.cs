using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public enum type{ Basic,Fire,Water,Earth,Lightning};
	[Header ("Required Attributes")]
	public int health;
	public int damage;
	public float speed;
	public type EnemyType;

	[Header("Is Game Paused")]
	public GameSettings gameSettings;

	[Header("Debugs")]
	public int currentWaypoint = 0;
	public int numOfWaypoints;
    public Pathfinder path;
    public Transform nextWaypoint;
	public Transform[] pathArray;

    private void Start()
    {
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();

		damage += gameSettings.difficulty;
		speed += gameSettings.difficulty;
		
		findPath();
    }

    private void Update()
    {
		if (!gameSettings.isPaused) {
			move();
		}
    }



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
			gameSettings.takeDamage(damage);
			Destroy(gameObject);
		} else {
			nextWaypoint = pathArray[currentWaypoint];
		}
		yield return new WaitForSeconds(1/gameSettings.gameSpeed);	
	}
	public void TakeDamage(int damage) {
		health -= damage;
		if (health <= 0) {
			gameSettings.MapMoney += damage;
			Destroy(gameObject);
		}
	}

}
