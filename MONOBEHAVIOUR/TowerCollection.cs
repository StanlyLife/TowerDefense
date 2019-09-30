using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCollection : MonoBehaviour
{
    [System.Serializable]
    public class Tower {
        public string TowerName;
        public GameObject RealTower;
        public GameObject DummyTower;
    }
    public Tower[] Towers;


}
