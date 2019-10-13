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
    [Header("Circle that changes color on invalid")]
    public GameObject RadiusCircle;
    private RadiusCircle radiusCircleScript;
    [Header("Placeable Script")]
    public Placeable canBePlaced;

    [Header("Debugs")]
    public float timeBetweenPlace;
    public float lastTimePlaced;
    public bool hasItemInHand = false;

    public void Start() {
        Instantiate(RadiusCircle, getCursorPosition(), RadiusCircle.transform.rotation);
        RadiusCircle = GameObject.FindGameObjectWithTag("Circle");
        radiusCircleScript = RadiusCircle.GetComponent<RadiusCircle>();
        road = GameObject.FindGameObjectWithTag("Road");


    }

    void Update()
    {
        CheckPlaceability();
        RemovePlace();
    }

    //regions good! https://enterprisecraftsmanship.com/posts/c-regions-is-design-smell/

    #region Check Placeability
    public void CheckPlaceability() {
        if (hasItemInHand && canBePlaced.canBePlaced) {

			Vector3 mousePosition = getCursorPosition();

			Vector2 itemSize;
			itemSize = item.GetComponentInChildren<BoxCollider2D>().size;

            Vector2 closestRigbodBound = road.GetComponent<Rigidbody2D>().ClosestPoint(mousePosition);
            float distance2 = Vector2.Distance(mousePosition, closestRigbodBound);
            //DEBUG//print("Distance 2: " + distance2);

            //Find diagonal of Item / absolute value
			float itemDiagonal = Mathf.Sqrt(
				Mathf.Pow(itemSize.x, 2)
				+
				Mathf.Pow(itemSize.y, 2)
				);
            
            //Should be divided by 2, but dividing by 3 gives more accurate answer
            float itemRadius = itemDiagonal / 3;
            
            if (distance2 >= itemRadius) {
                canBePlaced.canBePlaced = true;

				radiusCircleScript.SetColor(Color.green,false);
                Place();

            } else {
				radiusCircleScript.SetColor(Color.red,false);
                //canBePlaced.canBePlaced = false;
                    //^called in placeabletrigger instead
                
            }
        }
    }
    #endregion

    #region Hold Methods
    //Change item cursor is holding
    public void Hold(GameObject towerDummy,GameObject realTower) {
        item = realTower;
        Instantiate(towerDummy,transform);
        hasItemInHand = true;
    }
    public void RemoveHold() {
        if (item != null) {
            item = null;
            hasItemInHand = false;
            gameObject.GetComponentsInChildren<GameObjectFollowCursor>()[0].DestroyDummyTower();
        }
    }
    #endregion


    #region Place Method
    public void Place() {

        if (Input.GetMouseButtonDown(0) && Time.time > lastTimePlaced) {
			lastTimePlaced = Time.time + timeBetweenPlace;
            Vector3 cursorPosition = getCursorPosition();

            if (canBePlaced.canBePlaced) {
                Instantiate(item, cursorPosition, gameObject.transform.rotation);
            }
        }
    }
    
    public void RemovePlace() {
        if (Input.GetMouseButtonDown(1)) {
			radiusCircleScript.SetColor(Color.white,true);
            RemoveHold();
            canBePlaced.canBePlaced = true;
        }
    }
    
    #endregion

    #region get cursor positon
    public Vector2 getCursorPosition() {
        Vector2 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return pz;
    }
    #endregion
}
