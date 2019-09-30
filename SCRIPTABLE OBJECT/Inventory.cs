using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObject: Inventory")]
public class Inventory : ScriptableObject
{

    [Header ("Store Inventory Variables")]
    public int GlobalMoney;
    public int GlobalDiamonds;
    public int GlobalExperience;

    [Header ("Store current map Inventory Variables")]
    public int MapMoney;


}
