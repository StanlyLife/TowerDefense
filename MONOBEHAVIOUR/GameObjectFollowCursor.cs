using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFollowCursor : MonoBehaviour
{

    private void Update()
    {
        gameObject.transform.position = getCursorPosition(); 
    }

    public void DestroyDummyTower() {
        Destroy(gameObject);
    }


    public Vector3 getCursorPosition() {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        return pz;
    }
}
