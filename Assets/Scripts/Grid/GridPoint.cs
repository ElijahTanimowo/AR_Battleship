using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{

    [Header("Info Grid Point")]
    public bool hasShip;
    public bool isHit;

    [Header("Material of Grid Point")]
    [SerializeField] Material hit;
    [SerializeField] Material notHit;

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
            meshRender.material = hit;
        }
        else
        {
            meshRender.material = notHit;
        }
    }
}
