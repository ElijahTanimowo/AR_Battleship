using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [Header("Grid Info")]
    public GameObject player1TargetGrid;
    public GameObject player2TargetGrid;

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


}
