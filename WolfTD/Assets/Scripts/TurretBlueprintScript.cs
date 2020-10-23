using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//System.Serializable makes it so that we can easily recreate turret objects when needed
//This script assists in the building/upgrading of turrets by being a blueprint for the actual turrets in game.
[System.Serializable]
public class TurretBlueprintScript
{
    //Intializing variables that all turrets will/should have. Values for each variable may be different for each turret.
    //TurretPrefab/UpgradePrefab should be different for each type of turret.
    public GameObject turretPrefab;
    public int cost;
    public GameObject upgradePrefab;
    public int upgradeCost;
    

    //Functions returns the sell amount of a turret which is based on it's cost
    public int GetSellAmount()
    {
        return ((int)(cost * .65f));
    }
}
