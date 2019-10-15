using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTower : MonoBehaviour
{
	[Header("Ïnsert in inspector")]
	public TowerBase realTower;
	public Tower _Tower;
	private float targetRadius;
	private RadiusCircle circle;
	void Start()
    {
		circle = GameObject.FindGameObjectWithTag("Circle").GetComponent<RadiusCircle>();
		targetRadius = _Tower.radius;
		circle.SetScale(targetRadius);
		circle.SetColor(Color.white,false);
    }

}
