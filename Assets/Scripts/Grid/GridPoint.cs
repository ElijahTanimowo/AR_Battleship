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
    public Ship testShip;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            if (testShip == null)
            {
                hasShip = true;
                testShip = other.gameObject.GetComponent<Ship>();
                Debug.Log("Ship detected: " + testShip.name);
            }    
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
                Debug.Log("Ship detected: " + testShip.name);

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
