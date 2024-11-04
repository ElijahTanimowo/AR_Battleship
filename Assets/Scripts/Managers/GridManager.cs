using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [Header("Missile Info")]
    [SerializeField] GameObject missile;
    public MissileController missileObject1;
    public MissileController missileObject2;

    [Header("Grid Info")]
    public GameObject player1TargetGrid;
    [SerializeField] Transform missileLocationP1;
    [SerializeField] Transform missileLocationP2;
    public GameObject player2TargetGrid;

    [Header("Ships")]
    [SerializeField] Transform player1Ships;
    public int player1CurrentShips;
    [SerializeField] Transform player2Ships;
    public int player2CurrentShips;

    private void Awake()
    {
        //Game Manager in world, destory
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
        player1CurrentShips = player1Ships.childCount;
        player2CurrentShips = player2Ships.childCount;

    }

    private void Update()
    {
        player1CurrentShips = player1Ships.childCount;
        player2CurrentShips = player2Ships.childCount;

    }

    public void SetMissile()
    {
        if (GameManager.instance.currentTurn == PlayerTurn.Player1) 
        {
            GameObject missileToBeShot = Instantiate(missile, missileLocationP1.position, Quaternion.identity);
            missileObject1 = missileToBeShot.GetComponent<MissileController>();
            
        }
        else if (GameManager.instance.currentTurn == PlayerTurn.Player2)
        {
            GameObject missileToBeShot = Instantiate(missile, missileLocationP2.position, Quaternion.identity);
            missileObject2 = missileToBeShot.GetComponent<MissileController>();
        }
    }


}
