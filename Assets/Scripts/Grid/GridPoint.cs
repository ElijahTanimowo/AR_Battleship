using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{

    public bool hasShip;
    public bool isHit;

    MeshRenderer meshRender;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("There is a ship");
            hasShip = true;
        }
    }

    public void OnHitGridPoint()
    {
        if (hasShip) 
        {

        }
        else
        {

        }
    }
}
