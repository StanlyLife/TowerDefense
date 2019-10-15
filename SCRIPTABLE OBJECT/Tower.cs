using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Tower1", menuName = "Tower/TowerX") ]
public class Tower : ScriptableObject
{
	[Header ("TOWER ID")]
	public int towerID;
	public string TowerName;

	[Header ("GameObjects")]
	public GameSettings gameSettings;
	public GameObject projectile;
	public GameObject roadGizmo;

	[Header("Tower attributes")]
	public float radius;
	public float projectileCooldown;

	[Header("Projectile attributes")]
	public int projectileDamage;
	public float projectileSpeed;
	public float projectileLifeTime;

	[Header("Unused by Tower")]
	public int TotalDamageDealt;
	public int sellPrice;
	public int storePrice;
}
