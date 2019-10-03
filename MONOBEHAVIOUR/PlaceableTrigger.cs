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

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Dummy") {
         //print("Can now place");
         canPlace.canBePlaced = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Dummy") {
            //print("Cannot place dummy here");
            canPlace.canBePlaced = false;
            circleChange.changeColor(Color.red);
        }
    }



}
