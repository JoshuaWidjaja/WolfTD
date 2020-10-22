using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour
{
    public Vector3 offset;
    public Color hoverColor;
    public Color noMoneyColor;
    private Color startColor; 
    private Renderer renderObj;
    [HideInInspector]
    public GameObject currentTurret;
    [HideInInspector]
    public TurretBlueprintScript currentTurretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    BuildManagerScript buildManager;

    private Vector3 defaultOffset = new Vector3(0f, 0.5f, 0f);
    private Vector3 altOffset = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        renderObj = GetComponent<Renderer>();
        startColor = renderObj.material.color;
        buildManager = BuildManagerScript.instance;
    }

    public Vector3 getPosition()
    {
        return transform.position + offset;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

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

    private void OnMouseExit()
    {
        renderObj.material.color = startColor;
    }

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

    void BuildTurret(TurretBlueprintScript blueprint)
    {
        if (PlayerInfoScript.currency < blueprint.cost)
        {
            Debug.Log("Not enough currency!");
            return;

        }

        if (blueprint.turretPrefab.name == "LaserTurret")
        {
            offset = altOffset;
        }
        else
        {
            offset = defaultOffset;
        }

        PlayerInfoScript.currency -= blueprint.cost;
        
        GameObject turret = (GameObject)Instantiate(blueprint.turretPrefab, getPosition(), Quaternion.identity);
        currentTurret = turret;
        currentTurretBlueprint = blueprint;
        GameObject buildEffect = (GameObject)Instantiate(buildManager.turretBuildEffect, getPosition(), Quaternion.identity);
        Destroy(buildEffect, 4f);
        Debug.Log("Turret Built! Remaining Currency: ");
    }
    
    public void UpgradeTurret()
    {
        if (PlayerInfoScript.currency < currentTurretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough currency!");
            return;

        }
        PlayerInfoScript.currency -= currentTurretBlueprint.upgradeCost;
        Destroy(currentTurret);
        GameObject turret = (GameObject)Instantiate(currentTurretBlueprint.upgradePrefab, getPosition(), Quaternion.identity);
        currentTurret = turret;
        GameObject buildEffect = (GameObject)Instantiate(buildManager.turretBuildEffect, getPosition(), Quaternion.identity);
        Destroy(buildEffect, 4f);
        isUpgraded = true;
        Debug.Log("Turret Upgraded! Remaining Currency: ");
    }

    public void SellTurret()
    {
        PlayerInfoScript.currency += currentTurretBlueprint.GetSellAmount();

        GameObject sellEffect = (GameObject)Instantiate(buildManager.turretSellEffect, getPosition(), Quaternion.identity);
        Destroy(sellEffect, 4f);
        Destroy(currentTurret);
        currentTurretBlueprint = null;
    }
}
