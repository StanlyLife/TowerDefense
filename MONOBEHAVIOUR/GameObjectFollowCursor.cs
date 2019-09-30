using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFollowCursor : MonoBehaviour
{

    void Update()
    {
        gameObject.transform.position = getCursorPosition(); 
    }

    public Vector3 getCursorPosition() {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        return pz;
    }
}
