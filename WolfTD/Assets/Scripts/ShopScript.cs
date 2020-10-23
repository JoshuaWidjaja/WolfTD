using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script handles behavior for when player selects which type of turret they want to build next.
public class ShopScript : MonoBehaviour
{
    //Intializing turret types and buildmanager.
    public TurretBlueprintScript standardTurret;
    public TurretBlueprintScript missileTurret;
    public TurretBlueprintScript laserTurret;

    BuildManagerScript buildManager;
 
    // Start is called before the first frame update
    //Sets build manager on start
    void Start()
    {
        buildManager = BuildManagerScript.instance;
        
    }

    //If standard turret is selected, SelectTurretToBuild() is set to the standard Turret.
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected!");
        buildManager.SelectTurretToBuild(standardTurret);

    }

    //If missile turret is selected, SelectTurretToBuild() is instead set to the missile Turret.
    public void SelectMissileTurret()
    {
        Debug.Log("Missile Turret Selected!");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    //If laser turret is selected, SelectTurretToBuild() is set to the laser Turret.
    public void SelectLaserTurret()
    {
        Debug.Log("Laser Turret Selected!");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
