using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Player : MonoBehaviour
{
    [Space]
    public GameObject objectToSpawn;
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnGrid();
        SelectGridPoint();
    }

    private void SelectGridPoint()
    {
        //Grid exist
        if (spawnedObject != null)
        {
            //Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                //Check where screen hit
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject selectedGridPoint = hit.collider.gameObject;
                    //Check it is Enemy Grid Point
                    if (selectedGridPoint.tag == "EnemyGridPoint")
                    {
                        if (GameManager.instance.currentTurn == PlayerTurn.Player1 && selectedGridPoint.layer == LayerMask.NameToLayer("Player1Grid"))
                        {
                            CheckGridPoint(selectedGridPoint);
                        }
                        else if (GameManager.instance.currentTurn == PlayerTurn.Player2 && selectedGridPoint.layer == LayerMask.NameToLayer("Player2Grid"))
                        {
                            CheckGridPoint(selectedGridPoint);
                        }
                    }
                }
            }
            //Check for touch screen
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Check for screen touch input
                Touch touch = Input.GetTouch(0);
                //Check where screen hit
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject selectedGridPoint = hit.collider.gameObject;
                    //Check it is Enemy Grid Point
                    if (selectedGridPoint.tag == "EnemyGridPoint")
                    {
                        if (GameManager.instance.currentTurn == PlayerTurn.Player1 && selectedGridPoint.layer == LayerMask.NameToLayer("Player1Grid"))
                        {
                            CheckGridPoint(selectedGridPoint);
                        }
                        else if (GameManager.instance.currentTurn == PlayerTurn.Player2 && selectedGridPoint.layer == LayerMask.NameToLayer("Player2Grid"))
                        {
                            CheckGridPoint(selectedGridPoint);
                        }
                    }
                }
            }
        }
    }

    private void CheckGridPoint(GameObject selectedGridPoint)
    {
        
        //Debug.Log("Selected Grid Point: " + selectedGridPoint.name);
        CheckForShip(selectedGridPoint);
    }

    private void SpawnGrid()
    {
        if (spawnedObject != null)
            return;  // Exit if already have a grid spawned

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        // Perform the raycast to detect flat ground
        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds))
        {
            ARRaycastHit hit = hits[0];
            var plane = hit.trackable as ARPlane;

            // Check if the detected plane is horizontal (flat)
            if (plane.alignment == PlaneAlignment.HorizontalUp)
            {
                // Spawn the object at the hit point if nothing is spawned yet
                spawnedObject = Instantiate(objectToSpawn, hit.pose.position, objectToSpawn.transform.rotation);
            }
        }
    }

    void CheckForShip(GameObject gridPoint)
    {
        GridPoint point = gridPoint.GetComponent<GridPoint>();
        if (point != null) 
        {
            if (!point.isHit)
            {
                point.OnHitGridPoint();
                ShootMissile(gridPoint);
                PlayerManager.instance.CompleteMove();
            }
           
        }
    }

    void ShootMissile(GameObject selectedObject)
    {
        if (GameManager.instance.gridManager != null)
        {
            if (GameManager.instance.currentTurn == PlayerTurn.Player1)
            {
                GridManager.instance.missileObject1.target = selectedObject.transform;
                //Debug.Log("Player 1 shot");
            }
            else if (GameManager.instance.currentTurn == PlayerTurn.Player2)
            {
                GridManager.instance.missileObject2.target = selectedObject.transform;
                //Debug.Log("Player 2 shot");
            }

        }
    }
}
