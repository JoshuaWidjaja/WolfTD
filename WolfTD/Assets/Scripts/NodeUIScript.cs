using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NodeUIScript : MonoBehaviour
{
    public GameObject UI;
    private NodeScript targetNode;
    public Text upgradeCost;
    public Text sellCost;
    public Button upgradeButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTarget(NodeScript target)
    {
        targetNode = target;
        transform.position = targetNode.getPosition();

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

    public void hideUI()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        targetNode.UpgradeTurret();
        BuildManagerScript.instance.DeselectNode();
    }

    public void Sell()
    {
        targetNode.SellTurret();
        BuildManagerScript.instance.DeselectNode();
    }
}
