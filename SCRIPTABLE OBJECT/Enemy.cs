using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1", menuName = "Enemy/EnemyX")]
public class Enemy : ScriptableObject
{
		[Header ("Enemy Name")]
        public string name;
        [Header ("Enemy attributes")]
		public int killValue;
		public int health;
		public int enemyDamage;
		public float speed;

	public type EnemyType;
	public enum type
    {
            basic,fire,water,earth,lightning
    };

}
