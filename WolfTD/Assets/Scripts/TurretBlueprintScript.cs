using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprintScript
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject upgradePrefab;
    public int upgradeCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetSellAmount()
    {
        return ((int)(cost * .65f));
    }
}
