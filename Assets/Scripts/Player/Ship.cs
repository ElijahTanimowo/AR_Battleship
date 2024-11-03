using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ship : MonoBehaviour
{
    [Header("Ship Info")]
    public ShipTypes shipType;
    public int shipDurability;

    [Header("Explosion")]
    public ParticleSystem explosionPrefab;
    [SerializeField] Transform explosionLocation;

    public void DamageHull()
    {
        shipDurability--;
        PlayExplosion();

        if(shipDurability <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Sunk a " + this.name);
        }
    }

    public int GetShipDurability()
    {
        return shipDurability;
    }

    void PlayExplosion()
    {
        Instantiate(explosionPrefab, explosionLocation.position, Quaternion.identity);
    }
}
