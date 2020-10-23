using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script handles the UI for turrets when clicked on a node. Sets the UI for Upgrade and Sell text.
public class NodeUIScript : MonoBehaviour
{
    //Intializing variables
    public GameObject UI;
    public Text upgradeCost;
    public Text sellCost;
    public Button upgradeButton;
    private NodeScript targetNode;
    
    //Gets the position of the selected node, then displays the UI and the correct text based on whether the turret on that node is upgraded or not.
    public void SetTarget(NodeScript target)
    {
        targetNode = target;
        transform.position = targetNode.GetPosition();

        if (targetNode.isUpgraded == false)
        {
            upgradeCost.text = "$" + target.currentTurretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }   
        else
        {
            upgradeCost.text = "MAX UPGRADE";
            upgradeButton.interactable = false;
        }

        sellCost.text = "$" + target.currentTurretBlueprint.GetSellAmount();
        UI.SetActive(true);
    }


    //Helper function that hides the UI when node is deselected.
    public void HideUI()
    {
        UI.SetActive(false);
    }


    //Function called when upgrade button is clicked on node, calls the UpgradeTurret() function in the NodeScript file and then deselects the node.
    public void Upgrade()
    {
        targetNode.UpgradeTurret();
        BuildManagerScript.instance.DeselectNode();
    }

    //Function called when the sell button is clicked. Calls the SellTurret() function in the NodeScript file and then deselects the node.
    public void Sell()
    {
        targetNode.SellTurret();
        BuildManagerScript.instance.DeselectNode();
    }
}
