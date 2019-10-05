using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [System.Serializable]
    public class Paths
    {
        public string name;
        public Transform[] waypoints;
    }

    public Paths waypoints;


}