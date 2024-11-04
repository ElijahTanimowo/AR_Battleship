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

        

    }
    private void Start()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.player2Won = false;
            UIManager.Instance.player1Won = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        FindGrid();
        CheckBattleShipGame();
    }

    private void CheckBattleShipGame()
    {
        //if not exist end function
        if (grid != null && gridManager != null)
        {
            //Check no ships from player 1
            if (gridManager.player1CurrentShips <= 0)
            {
                Debug.Log("Player 2 Won");
                if (UIManager.Instance != null) 
                {
                    UIManager.Instance.player2Won = true;
                    UIManager.Instance.OnSceneChange("WinLoseScreen");
                }
            }
            //Check no ships from player 2
            if (gridManager.player2CurrentShips <= 0)
            {
                if (UIManager.Instance != null)
                {
                    UIManager.Instance.player1Won = true;
                    UIManager.Instance.OnSceneChange("WinLoseScreen");
                }
            }
        }
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
            currentTurn = PlayerTurn.Player1;
            gridManager.SetMissile();
        }
        
    }

    public void EndTurn()
    {
        if (currentTurn == PlayerTurn.Player1)
            currentTurn = PlayerTurn.Player2;
        else
            currentTurn = PlayerTurn.Player1;
  
        gridManager.SetMissile();
    }
}
