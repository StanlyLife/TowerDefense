using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Pathfinder path;
    private Transform waypoint;
    private int nextWaypointGoal = 0;
    private Vector2 enemy;
    void Start()
    {
        //enemy = gameObject.GetComponent<Vector2>();
        NextWaypoint();
    }

    void Update()
    {
        move();
    }


    private void move() {
        if (NextWaypoint() != null) {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, NextWaypoint().position, 3 * Time.deltaTime);
        }
    }

    private Transform NextWaypoint() {
        waypoint = path.waypoints.waypoints[nextWaypointGoal];
        return waypoint;
    }

    public void OnTriggerEnter2D(Collider2D waypoint) {
        if (waypoint.tag.ToLower() == "waypoint") {
            print("getting next waypoint");
            nextWaypointGoal++;
            NextWaypoint();
        } else if(waypoint.tag.ToLower() == "end"){
            //do damage
            Destroy(gameObject);
        }
    }

}
