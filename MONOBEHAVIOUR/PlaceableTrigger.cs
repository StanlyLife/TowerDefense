using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTrigger : MonoBehaviour
{
    [Header ("Placeable Script")]
    [Tooltip ("Change canPlace attribute true & false")]public Placeable canPlace;
    [Header("HandHolder Script")]
    [Tooltip ("change color of the radius circle")]public PlaceItem circleChange;

    private void Start() {
        circleChange = GameObject.FindGameObjectWithTag("ScriptHolder").GetComponent<PlaceItem>();
    }

    private void OnMouseOver() {
        print("cannot place");
        canPlace.canBePlaced = false;
        circleChange.changeColor(Color.red);
    }

    private void OnMouseExit() {
        canPlace.canBePlaced = true;
        circleChange.changeColor(Color.green);
    }
}
