using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Placeable", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [System.Serializable]
    public class Enemies
    {
        public string name;
        [Header ("Enemy attributes")]
        public int damage;
        public float speed;
        public int health;
        public int maxHealth;
        public enemyType EnemyType;
    }
    [HideInInspector]
    public enum enemyType
        {
            basic,fire,water,earth,lightning
        };
    public float GlobalSpeed;
    public int GlobalHealth;
    public int GlobalMaxHealth;
    public Enemies[] enemies;
}
