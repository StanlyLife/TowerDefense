using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTower : MonoBehaviour
{
	[Header("Debug")]
	public TowerBase realTower;
	[SerializeField]
	private float targetRadius;
	[SerializeField]
	private RadiusCircle circle;
	void Start()
    {
		circle = GameObject.FindGameObjectWithTag("Circle").GetComponent<RadiusCircle>();
		targetRadius = realTower.targetRadius;
		circle.SetScale(targetRadius);
		circle.SetColor(Color.white,false);
    }

}
