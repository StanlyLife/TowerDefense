using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GlobalStorage", menuName = "ScriptableObject: Global storage")]
public class GlobalStorage : ScriptableObject
{
    //speed x3, speed x1
    public float gameSpeed;
    [Tooltip ("Is game paused, true false")]public bool isPaused;
}
