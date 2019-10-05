using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GlobalStorage", menuName = "ScriptableObject: Global storage")]
public class GlobalStorage : ScriptableObject
{
	[Header ("Game Settings")]
    //speed x3, speed x1
    public float gameSpeed = 1;
    [Tooltip ("Is game paused, true false")]public bool isPaused = false;
	[Header ("Game attributes")]
	public int gameHealth;
	public int MapMoney;


	[Header("Global Game Attributes")]
	public int GlobalMoney;
	public int GlobalDiamonds;
	public int GlobalExperience;


}
