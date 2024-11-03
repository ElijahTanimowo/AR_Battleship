using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public ShipTypes shipType;
    public int shipDurability;

    public void DamageHull()
    {
        shipDurability--;
    }

    public int GetShipDurability()
    {
        return shipDurability;
    }
}
