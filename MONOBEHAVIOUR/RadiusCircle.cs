using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusCircle : MonoBehaviour
{
	private SpriteRenderer sprite;
	private void Start() {
		sprite = gameObject.GetComponent<SpriteRenderer>();
	}
	public void SetColor(Color newColor,bool transparent) {
		if (transparent) {
			newColor.a = 0;
			sprite.color = newColor;
		} else {
			newColor.a = .1f;
			sprite.color = newColor;
		}
	}

	public void SetScale(float scale) {
		transform.localScale = new Vector3(scale/1.7f,scale/1.7f,147);
	}
}
