using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class BuildingManager : MonoBehaviour
{
    public CityManager CityManager;

    public Building CurrentBuilding { get; private set; }

    public GameObject buildingButtonObject;
    public GameObject buildingListObject;

    public GoodsCollection Inventory { get; set; }
    public BuildingsCollection Buildings { get; set; }

    //TODO this shouldn't be here
    public GoodsCollection IncomeInventory { get; set; }

    [SerializeField] private Button[] _modeButtons = new Button[4];

    private void Start ()
    {
        IncomeInventory = new GoodsCollection(0);
        Inventory = new GoodsCollection(100);
        GuiManager.UpdateGui(Inventory);
        Buildings = new BuildingsCollection();

        Inventory.OnCollectionChange += (collection, args) => 
        {
            GuiManager.UpdateGui(Inventory);
        };

        Globals.GridManager.OnBuildingPlaced -= PlaceBuilding;
        Globals.GridManager.OnBuildingPlaced += PlaceBuilding;

        foreach (var key in BuildingBlueprint.Keys)
        {
            BuildingBlueprint b = BuildingBlueprint.Blueprints[key];

            var btn = Instantiate(buildingButtonObject);
            btn.transform.SetParent(buildingListObject.transform);
            btn.transform.localScale = Vector3.one;

            var bb = btn.GetComponent<BuildingButton>();
            bb.InitializeBuildingButton(this, b);
            b.BuildingButton = bb;
        }

        _modeButtons[0].GetComponent<Button>().onClick.AddListener(() => { OnModeButtonClick(0); });
        _modeButtons[1].GetComponent<Button>().onClick.AddListener(() => { OnModeButtonClick(1); });
        _modeButtons[2].GetComponent<Button>().onClick.AddListener(() => { OnModeButtonClick(2); });
        _modeButtons[3].GetComponent<Button>().onClick.AddListener(() => { OnModeButtonClick(3); });

        var researchManager = new ResearchManager();
        researchManager.GetResearchTree();
    }

    public Building SetCurrentBuilding(Building b)
    {
        if (CurrentBuilding?.GridCell != null)
        {
            CurrentBuilding.GridCell.Selected = false;
        }
        
        CurrentBuilding = b;

        if (CurrentBuilding != null)
        {
            for (int i = 0; i < _modeButtons.Length; i++)
            {
                _modeButtons[i].gameObject.SetActive(i <= CurrentBuilding.Blueprint.BuildingEffects.Count - 1);
            }

            if (CurrentBuilding?.GridCell != null)
            {
                CurrentBuilding.GridCell.Selected = true;
            }
        }

        GuiManager.UpdateBuildingDetailGui(CurrentBuilding);

        return CurrentBuilding;
    }

    public Building StartBuildingConstruction(BuildingBlueprint blueprint)
    {
        // //TODO START HACK we need that BuildingBlueprint to create a new Building()
        // b = (Building)System.Activator.CreateInstance(b.GetType());
        // b.Sprite = Resources.Load<Sprite>(b.Blueprint.BuildingName);
        // //END HACK

        var b = new Building(blueprint);

        b.ResetProduction();
        Globals.GridManager.EnableBuildingGhost(b);
        SetCurrentBuilding(b);
        return b;
    }

    public void PlaceBuilding(Building b, Action<Building> assignGridDict)
    {
        var missingGoods = b.TryStartConstruction(Inventory);
        if (missingGoods.Count > 0)
        {
            Globals.PopupText.PopUp("Missing - " + missingGoods);
            Debug.Log("Missing - " + missingGoods);
            return;
        }

        Buildings.Add(b);
        CityManager.AddCoin(-b.Blueprint.CoinCost);

        assignGridDict?.Invoke(b);
        b.GridCell.SetTimerText(b.Blueprint.ProductionCost);
    }

    public void ImproveBuilding(Building b)
    {
        var missingGoods = b.TryStartConstruction(Inventory);
        if (missingGoods.Count > 0)
        {
            Globals.PopupText.PopUp("Missing - " + missingGoods);
            Debug.Log("Missing - " + missingGoods);
            return;
        }

        CityManager.AddCoin(-b.Blueprint.CoinCost);
        b.ResetProduction();
        b.GridCell.SetTimerText(b.Blueprint.ProductionCost);

        GuiManager.UpdateBuildingDetailGui(b);
    }

    public void HandleBuildingsOnEndTurn()
    {
        IncomeInventory = Buildings.HandleBuildingsOnEndTurn(Inventory);
    }

    private void OnModeButtonClick(int index)
    {
        if (index < CurrentBuilding.Blueprint.BuildingEffects.Count)
        {
            CurrentBuilding.BuildingEffect = CurrentBuilding.Blueprint.BuildingEffects[index];
            CurrentBuilding.BuildingEffect?.Invoke(Inventory);
            GuiManager.UpdateBuildingDetailGui(CurrentBuilding);
        }
    }
}
