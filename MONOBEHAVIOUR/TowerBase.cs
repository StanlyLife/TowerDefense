using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public enum target {
        first,last,strong,weak
    };
	[Header("Game Settings")]
	public GameSettings gameSettings;
    [Header ("Base attributes")]
    public int upgrade;
	public float targetRadius;
    public target targetPriority;

    [Header("Move Towards Road")]
    public GameObject headHolder;
    public GameObject visualiseRoad;
	[HideInInspector]
	public int normaliseRotationBy = -90;
    private GameObject road;
    private Rigidbody2D towerRigBod;

	[Header("Projectile attributes")]
	public GameObject GoProjectile;
    public int damage;
	public float projectileSpeed;
	public float projectileLife;
	public float timeBetweenProjectiles;

	[Header("DEBUG")]
    public List<GameObject> enemyList = new List<GameObject>();
	//[HideInInspector]
	public float lastProjectileTime;
    public virtual void Start()
    {
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
        towerRigBod = gameObject.GetComponent<Rigidbody2D>();
        road = GameObject.FindGameObjectWithTag("Road");

		gameObject.GetComponent<CircleCollider2D>().radius = targetRadius;

        RotateHeadToRoad();
    }


	private void RotateHeadToRoad() {
        Vector3 direction = FindRoad() - headHolder.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + normaliseRotationBy;

        headHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            enemyList.Add(collision.gameObject);
/*
			foreach(GameObject go in enemyList) {
				if (go == null) {
					enemyList.Remove(go);
				}
			}
*/
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Enemy") && enemyList.Count > 0) {
			try {
				enemyList.RemoveAt(0);
			} catch (System.Exception e) when (e is System.InvalidOperationException) {
					Debug.Log("ERROR in OnTriggetrExit2D() TowerBase: " + e);
					Destroy(gameObject);
			}
		}
    }


    public void lookAt(GameObject go) {
        if (go != null) {
			Vector3 direction = go.transform.position - headHolder.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + normaliseRotationBy;
            headHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    private Vector3 FindRoad() {
        Vector3 roadVector = road.GetComponent<Rigidbody2D>().ClosestPoint(transform.position);
        Instantiate(visualiseRoad, roadVector, transform.rotation,transform);
        return roadVector;
    }
}
