using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//test
public class PlaceItem : MonoBehaviour
{
    [HideInInspector]
    public GameObject road;
    [Header("Item to place")]
    public GameObject item;
    [Header("GameObject to follow mouse")]
    public GameObject towerFollowMouse;
    [Header("Circle that changes color on invalid")]
    public GameObject RadiusCircle;
    private SpriteRenderer radiusCircleSR;
    [Header("Placeable Script")]
    public Placeable canBePlaced;

    [Header("Debugs")]
    public float timeBetweenPlace;
    public float lastTimePlaced;

    //private Color placeFalse = new Color(11,100,90,30);

    
    public bool hasItemInHand = false;
    
    //TODO UpdatePlaceAble
        //Find nearest tower, if close to bounds, canplace = false

    public void Start() {
        Instantiate(RadiusCircle, getCursorPosition(), RadiusCircle.transform.rotation);
        RadiusCircle = GameObject.FindGameObjectWithTag("Circle");
        radiusCircleSR = RadiusCircle.GetComponent<SpriteRenderer>();
        road = GameObject.FindGameObjectWithTag("Road");
    }

    void Update()
    {
        
        UpdatePlaceAble();
        //Place();
    }

    //Check if canPlaceTower = true
    public void UpdatePlaceAble() {

        //mouseposition
        Vector3 mousePosition = getCursorPosition();
        //Get size of gameObject
        Vector2 itemSize = item.GetComponent<BoxCollider2D>().size;
        //closest point to cursor of collider
        Vector2 distanceToCursorFromRoad = road.GetComponent<BoxCollider2D>().bounds.ClosestPoint(getCursorPosition());
        //distance between road and cursor
        float cursorDistance = Vector2.Distance(mousePosition, distanceToCursorFromRoad);

        //Find diagonal of Item //Absolutt verdi
        float itemDiagonal = Mathf.Sqrt(
            Mathf.Pow(itemSize.x,2)
            +
            Mathf.Pow(itemSize.y, 2)
            );
        //Should be divided by 2, but dividing by 3 gives more accurate answer
        float itemRadius = itemDiagonal/3;


        if (itemRadius <= cursorDistance) {
            //can place
            changeColor(Color.green);
            RadiusCircle.SetActive(true);
            Place();
        }
        else if(itemRadius > cursorDistance){
            //RadiusCircle.SetActive(false);
            //cannot place
            changeColor(Color.red);
        } else {
            Debug.Log("Error in color changing");
        }
    }

    //Change item cursor is holding
    public void Hold(GameObject towerDummy, GameObject realTower) {
        towerFollowMouse = towerDummy;
        item = realTower;
        Instantiate(towerDummy,transform);
        hasItemInHand = true;
    }
    public void RemoveHold() {
        hasItemInHand = false;
    }

    public void changeColor(Color c) {
        c.a = .25f;
        if(c != radiusCircleSR.color) {
            print("changed color");
            radiusCircleSR.color = c;
        }
    }

    public void Place() {
        if(Input.GetMouseButtonDown(0) && Time.time > lastTimePlaced) {

            lastTimePlaced = Time.time + timeBetweenPlace;
            Vector3 cursorPosition = getCursorPosition();

            if (canBePlaced.canBePlaced) {
                Instantiate(item, cursorPosition, gameObject.transform.rotation);
            }
        }else if (Input.GetMouseButtonDown(1)) {
            //Right Click
        }
    }
    public Vector3 getCursorPosition() {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        return pz;
    }
}
