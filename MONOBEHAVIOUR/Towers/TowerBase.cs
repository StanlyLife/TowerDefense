using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
	[Header ("TOWER SO")]
	public Tower _Tower;

    public enum target {
        first,last,strong,weak
    };
	#region common attributes
	//SCRIPTS
	protected GameSettings gameSettings;
	//GAMEOBJECTS
	protected GameObject GoProjectile;
    private GameObject visualiseRoad;
	//INT
	[HideInInspector]
    public int damage;
	[HideInInspector]
	public int ID;
	//FLOAT
	[HideInInspector]
	public float targetRadius;
	[HideInInspector]
	public float projectileSpeed;
	[HideInInspector]
	public float projectileLife;
	protected float timeBetweenProjectiles;
	#endregion
	[Header ("Unique Values")]
	/*ENUM*/
	public target targetPriority;
	/*public*/
    public GameObject headHolder;
	public int damageDealt;

	/*private*/
    private Rigidbody2D road;
	private Rigidbody2D towerRigBod;

	/*Protected*/
    protected int upgrade;
	protected float lastProjectileTime;
	/*Public hide*/
	[HideInInspector]
    public List<GameObject> enemyList = new List<GameObject>();
	[HideInInspector]
	public int normaliseRotationBy = -90;





	public virtual void Start()
    {
		FindAttributes();
		SetAttributes();

        RotateHeadToRoad();
	}
	private void SetAttributes() {
		//SCRIPTS
		gameSettings = GameObject.FindGameObjectWithTag("MapSettings").GetComponent<GameSettings>();
		if (gameSettings == null) {
			gameSettings = _Tower.gameSettings;
		}
		
		//GAMEOBJECTS
		GoProjectile = _Tower.projectile;
		visualiseRoad = _Tower.roadGizmo;
		//INT
		damage = _Tower.projectileDamage;
		timeBetweenProjectiles = _Tower.projectileCooldown;
		ID = _Tower.towerID;
		//FLOAT
		targetRadius = _Tower.radius;
		projectileSpeed = _Tower.projectileSpeed;
		projectileLife = _Tower.projectileLifeTime;

		//Set radius
		gameObject.GetComponent<CircleCollider2D>().radius = targetRadius;
	}


	private void FindAttributes() {
        towerRigBod = gameObject.GetComponent<Rigidbody2D>();
		road = GameObject.FindGameObjectWithTag("Road").GetComponent<Rigidbody2D>();
	}

	private void RotateHeadToRoad() {
        Vector3 direction = FindRoad() - headHolder.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + normaliseRotationBy;

        headHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void lookAt(GameObject go) {
        if (go != null) {
			Vector3 direction = go.transform.position - headHolder.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + normaliseRotationBy;
            headHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private Vector3 FindRoad() {
        Vector3 roadVector = road.ClosestPoint(transform.position);
        Instantiate(visualiseRoad, roadVector, transform.rotation,transform);
        return roadVector;
    }
}
