using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public enum type{ Basic,Fire,Water,Earth,Lightning};
	[Header ("Required Attributes")]
	public type EnemyType;
	public int health;
	public float speed;
	public int damage;
    public Pathfinder path;
    private Transform waypoint;
    private int nextWaypointGoal = 0;
	[Header("Is Game Paused")]
	public GameSettings gameSettings;
    private void Start()
    {
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
		FindGameObjects();
        NextWaypoint();
    }

    private void Update()
    {
		if (!gameSettings.isPaused) {
			move();
		}
    }

    private void FindGameObjects() {
        path = GameObject.FindGameObjectWithTag("Pathfinder").GetComponent<Pathfinder>();
    }

    public void move() {
        if (NextWaypoint() != null) {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, NextWaypoint().position, speed * Time.deltaTime * gameSettings.gameSpeed);
        } else {
            print("NextWaypoint() == null, destroyed enemy");
            Destroy(gameObject);
        }
    }

    private Transform NextWaypoint() {
        waypoint = path.waypoints.waypoints[nextWaypointGoal];
        return waypoint;
    }

    public void OnTriggerEnter2D(Collider2D waypoint) {
        if (waypoint.tag.ToLower() == "waypoint") {
            nextWaypointGoal++;
            NextWaypoint();
        } else if(waypoint.tag.ToLower() == "end"){
			gameSettings.takeDamage(damage);
            Destroy(gameObject);
        }
    }

	public void TakeDamage(int damage) {
		health -= damage;
		if (health >= 0) {
			Destroy(gameObject);
		}
	}

}
