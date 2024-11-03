using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Info")]
    [SerializeField] GameObject grid;
    [SerializeField] GridManager gridManager;
    public bool player1Turn;
    public bool player2Turn;

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
    // Start is called before the first frame update
    void Start()
    {
        
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

        grid = GameObject.FindWithTag("Grid");

        if (grid != null && grid.GetComponent<GridManager>()) 
        {
            gridManager = grid.GetComponent<GridManager>();
        }
        
    }
}
