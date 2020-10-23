using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Handles node behavior and contains functions for determining when mouse is over a node.

public class NodeScript : MonoBehaviour
{
    //Intializing variables. 
    public Vector3 offset;
    public Color hoverColor;
    public Color noMoneyColor;
    public bool isUpgraded = false;
    BuildManagerScript buildManager;

    private Color startColor; 
    private Renderer renderObj;
    private Vector3 defaultOffset = new Vector3(0f, 0.5f, 0f);
    private Vector3 altOffset = new Vector3(0f, 0f, 0f);

    [HideInInspector]
    public GameObject currentTurret;
    [HideInInspector]
    public TurretBlueprintScript currentTurretBlueprint;
    [HideInInspector]
    

   

    // Start is called before the first frame update
    //Assigns renderObj as a renderer to correctly display colors. Also assigns startColor and buildManager as their intended default values.
    void Start()
    {
        renderObj = GetComponent<Renderer>();
        startColor = renderObj.material.color;
        buildManager = BuildManagerScript.instance;
    }

    // ************ HELPER FUNCTIONS ************

    //Helper funcitons retrieves the position of the node and adds offset vector to it. Used when creating/building a new turret so that it doesn't clip into the node.
    public Vector3 GetPosition()
    {
        return transform.position + offset;
    }
  
    //Called when player hovers mouse over the Node. If building is possible on the node and the player has enough money for the turret, color of node is changed to hoverColor.
    //Else, noMoneyColor is the color of the node. If building is not possible on the node, then function returns.
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if (buildManager.hasMoney)
        {
            renderObj.material.color = hoverColor;
        }
        else
        {
            renderObj.material.color = noMoneyColor;
        }

        //renderObj.material.color = hoverColor;
    }


    //When mouse exists the node area, renderObj is set back to the default color.
    private void OnMouseExit()
    {
        renderObj.material.color = startColor;
    }


    //On mouse click, checks to see if mouse is over valid gameObject. Then checks to see if a turret already exists on that node. If it does, selects the node and then returns.
    //If no turret exists on the node, build a new one on that node.
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (currentTurret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
        
    }

    //Helper function for building turret. First checks to see that player has enough money to build or not. If it does, subtracts that from the player's currency, and then
    //creates the object on the position returned by the GetPosition() function. Also instantiates the build turret effect.
    void BuildTurret(TurretBlueprintScript blueprint)
    {
        if (PlayerInfoScript.currency < blueprint.cost)
        {
            Debug.Log("Not enough currency!");
            return;

        }

        //Laser turret needs a different offset than the other turrets, due to it being slightly larger.
        if (blueprint.turretPrefab.name == "LaserTurret")
        {
            offset = altOffset;
        }
        else
        {
            offset = defaultOffset;
        }

        PlayerInfoScript.currency -= blueprint.cost;
        
        GameObject turret = (GameObject)Instantiate(blueprint.turretPrefab, GetPosition(), Quaternion.identity);
        currentTurret = turret;
        currentTurretBlueprint = blueprint;
        GameObject buildEffect = (GameObject)Instantiate(buildManager.turretBuildEffect, GetPosition(), Quaternion.identity);
        Destroy(buildEffect, 4f);
        Debug.Log("Turret Built! Remaining Currency: ");
    }
    

    //Helper function for upgrading turreets. Checks to see if player has enough currency at first. If it does, that currency is subtracted from the player, and then the old turret is destroyed,
    //and a new upgraded version is built in the same position. 
    public void UpgradeTurret()
    {
        if (PlayerInfoScript.currency < currentTurretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough currency!");
            return;

        }
        PlayerInfoScript.currency -= currentTurretBlueprint.upgradeCost;
        Destroy(currentTurret);
        GameObject turret = (GameObject)Instantiate(currentTurretBlueprint.upgradePrefab, GetPosition(), Quaternion.identity);
        currentTurret = turret;
        GameObject buildEffect = (GameObject)Instantiate(buildManager.turretBuildEffect, GetPosition(), Quaternion.identity);
        Destroy(buildEffect, 4f);
        isUpgraded = true;
        Debug.Log("Turret Upgraded! Remaining Currency: ");
    }

    //Adds a set amount of currency to the player's currency and destroys the turret at the selected node. Also displays the sell particle effect.
    public void SellTurret()
    {
        PlayerInfoScript.currency += currentTurretBlueprint.GetSellAmount();

        GameObject sellEffect = (GameObject)Instantiate(buildManager.turretSellEffect, GetPosition(), Quaternion.identity);
        Destroy(sellEffect, 4f);
        Destroy(currentTurret);
        currentTurretBlueprint = null;
    }
}
