using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{

    [Header("Info Grid Point")]
    public bool hasShip;
    public bool isHit;
    [SerializeField] GameObject counterPart;
    GridPoint opp;
    [SerializeField] GameObject getShipObject;

    [Header("Material of Grid Point")]
    [SerializeField] Material hit;
    [SerializeField] Material notHit;

    public MeshRenderer meshRender;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();

        if(counterPart != null)
        {
            opp = counterPart.GetComponent<GridPoint>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            hasShip = true;
            getShipObject = other.gameObject;
            
        }
    }

    public void OnHitGridPoint()
    {
        if (opp != null)
        {
            if (opp.hasShip)
            {
                this.meshRender.material = hit;
                opp.meshRender.material = hit;
                if (getShipObject != null)
                {
                    Ship ship = getShipObject.GetComponentInParent<Ship>();
                    if (ship)
                    {
                        Debug.Log("hello");
                    }
                }
            }
            else
            {
                this.meshRender.material = notHit;
                opp.meshRender.material = notHit;
            }

            this.isHit = true;
            opp.isHit = true;
        }
    }
}
