using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTrigger : MonoBehaviour {
	[Header("Placeable Script")]
	[Tooltip("Change canPlace attribute true & false")] public Placeable canPlace;
	[Tooltip("change color of the radius circle")] private RadiusCircle circleChange;


	private bool hover = false;

	public void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.tag == "Dummy" && collision is BoxCollider2D) {
			//print("Can now place");
			canPlace.canBePlaced = true;
		}
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Dummy" && collision is BoxCollider2D) {
			circleChange = GameObject.FindGameObjectWithTag("Circle").GetComponent<RadiusCircle>();
			//print("Cannot place dummy here");
			canPlace.canBePlaced = false;
			circleChange.SetColor(Color.red, false);
		}
	}
}

