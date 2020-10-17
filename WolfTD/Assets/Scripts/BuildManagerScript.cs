using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManagerScript : MonoBehaviour
{
    public static BuildManagerScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager found!");
            return;
        }
        instance = this;
    }

    public GameObject turretBuildEffect;
    public GameObject turretSellEffect;
    
    private TurretBlueprintScript selectedTurretType;
    private NodeScript selectedNode;
    public NodeUIScript nodeUI;
    public bool canBuild { get { return selectedTurretType != null; } }
    public bool hasMoney { get { return PlayerInfoScript.currency >= selectedTurretType.cost; } }


    public void selectTurretToBuild(TurretBlueprintScript turretToBuild)
    {
        selectedTurretType = turretToBuild;
        deselectNode();
    }

    public void selectNode (NodeScript node)
    {
        if (selectedNode == node)
        {
            deselectNode();
            return;
        }
        selectedNode = node;
        selectedTurretType = null;
        nodeUI.setTarget(node);
    }
    


    public void deselectNode()
    {
        selectedNode = null;
        nodeUI.hideUI();
    }

    public TurretBlueprintScript GetTurretToBuild()
    {
        return selectedTurretType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
