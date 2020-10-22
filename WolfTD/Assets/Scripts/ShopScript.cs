using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public TurretBlueprintScript standardTurret;
    public TurretBlueprintScript missileTurret;
    public TurretBlueprintScript laserTurret;

    BuildManagerScript buildManager;
 
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManagerScript.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectStandardTurret()
    {
        Debug.Log("Standard Turret Selected!");
        buildManager.SelectTurretToBuild(standardTurret);

    }

    public void selectMissileTurret()
    {
        Debug.Log("Missile Turret Selected!");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void selectLaserTurret()
    {
        Debug.Log("Laser Turret Selected!");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
