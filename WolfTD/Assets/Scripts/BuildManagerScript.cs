using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is the BuildManager, which contains helper functions and variables that aid in the building of turret when selected. Also contains functions that ease the 
//selection and deselection of nodes.
public class BuildManagerScript : MonoBehaviour
{
    public static BuildManagerScript instance;

    //Checks for multiple instances of BuildManager, else assigns it
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager found!");
            return;
        }
        instance = this;
    }

    //Initializing variables
    public GameObject turretBuildEffect;
    public GameObject turretSellEffect;
    public NodeUIScript nodeUI;

    private TurretBlueprintScript selectedTurretType;
    private NodeScript selectedNode;

    //Returns true or false, for given formulas. We then used canBuild and hasMoney in later functions.
    public bool canBuild
    {
        get
        {
            return selectedTurretType != null;
        }
    }
    public bool hasMoney
    {
        get
        {
            return PlayerInfoScript.currency >= selectedTurretType.cost;
        }
    }

    // ************ HELPER FUNCTIONS ************

    //Changes the turret that will be built when the player clicks on a node. Activated by clicking shop icons, which deselects any node if it is already selected
    public void SelectTurretToBuild(TurretBlueprintScript turretToBuild)
    {
        selectedTurretType = turretToBuild;
        DeselectNode();
    }


    //Selects the node clicked. If already selected, deselects the node.
    public void SelectNode(NodeScript node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        selectedTurretType = null;
        nodeUI.setTarget(node);
    }


    //Helper function for deselecting a selected node. Also hides upgrade UI if currently showing.
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.hideUI();
    }

    //Helper function utilized in the Node script to return the correct turret to build in the node. 
    public TurretBlueprintScript GetTurretToBuild()
    {
        return selectedTurretType;
    }

   
}

