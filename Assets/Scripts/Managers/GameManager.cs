using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Info")]
    [SerializeField] GameObject grid;
    public GridManager gridManager;
    public PlayerTurn currentTurn;

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

        currentTurn = PlayerTurn.Player1;

    }


    // Update is called once per frame
    void Update()
    {
        FindGrid();
    }

    /// <summary>
    /// Finds the grid in world
    /// </summary>
    private void FindGrid()
    {
        //if exist end function
        if(grid != null && gridManager != null) return;

        //Find Object with tag Grid
        grid = GameObject.FindWithTag("Grid");

        //Check grid exist
        if (grid != null && grid.GetComponent<GridManager>()) 
        {
            //Assign the Manager
            gridManager = grid.GetComponent<GridManager>();
        }
        
    }

    public void EndTurn()
    {
        if (currentTurn == PlayerTurn.Player1)
        {
            currentTurn = PlayerTurn.Player2;
        }
        else
        {
            currentTurn = PlayerTurn.Player1;
        }
    }
}
