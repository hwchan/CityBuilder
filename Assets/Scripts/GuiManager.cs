using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GuiManager : MonoBehaviour
{
    [SerializeField] private InventoryPanel _inventoryPanel;
    [SerializeField] private BuildingPanel _buildingPanel;
    [SerializeField] private ConstructionCostPanel _constructionCostPanel;

    public static GuiManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateBuildingDetails(BuildingBlueprint building)
    {
        if (building == null)
        {
            return;
        }

        _buildingPanel.UpdateBuildingDetails(building);
        _constructionCostPanel.UpdateBuildingCost(building);
    }

    public void UpdateInventory(GoodsCollection inventory)
    {
        _inventoryPanel.UpdateInventory(inventory);
    }
}
