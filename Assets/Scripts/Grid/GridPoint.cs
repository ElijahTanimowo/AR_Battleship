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
        if (opp != null)
        {
            if (opp.hasShip)
            {
                this.meshRender.material = hit;
                opp.meshRender.material = hit;
                this.isHit = true;
                opp.isHit = true;
            }
            else
            {
                this.meshRender.material = notHit;
                opp.meshRender.material = notHit;
            }
        }
    }
}
