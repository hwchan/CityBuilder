using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public CityManager CityManager;

    public Building CurrentBuilding { get; private set; }

    public GameObject buildingButtonObject;
    public GameObject buildingListObject;

    public GoodsCollection Inventory { get; set; }
    public BuildingsCollection Buildings { get; set; }  //TODO
    public BuildingsCollection2 Buildings2 { get; set; }

    //TODO this shouldn't be here
    public GoodsCollection IncomeInventory { get; set; }

    [SerializeField] private Button[] _modeButtons = new Button[4];

    void Start ()
    {
        IncomeInventory = new GoodsCollection(0);
        Inventory = new GoodsCollection(100);
        GuiManager.UpdateGui(Inventory);
        Buildings2 = new BuildingsCollection2();

        Inventory.OnCollectionChange += (collection, args) => 
        {
            GuiManager.UpdateGui(Inventory);
        };

        Globals.GridManager.OnBuildingPlaced -= PlaceBuilding;
        Globals.GridManager.OnBuildingPlaced += PlaceBuilding;

        //TODO
        Buildings = new BuildingsCollection();
        foreach (var key in Buildings.Keys)
        {
            Building b = Buildings[key];
            b.Sprite = Resources.Load<Sprite>(b.BuildingName);

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
    }

    public Building SetCurrentBuilding(Building b)
    {
        if (CurrentBuilding?.GridCell != null)
        {
            CurrentBuilding.GridCell.Selected = false;
        }
        
        CurrentBuilding = b;

        for (int i = 0; i < _modeButtons.Length; i++)
        {
            _modeButtons[i].gameObject.SetActive(i <= CurrentBuilding.BuildingEffects.Count - 1);
        }

        if (CurrentBuilding?.GridCell != null)
        {
            CurrentBuilding.GridCell.Selected = true;
        }

        GuiManager.UpdateBuildingDetailGui(CurrentBuilding);

        return CurrentBuilding;
    }

    public Building StartBuildingConstruction(Building b)
    {
        var missingGoods = b.TryStartConstruction(Inventory);
        if (missingGoods.Count > 0)
        {
            Globals.PopupText.PopUp("Missing - " + missingGoods);
            Debug.Log("Missing - " + missingGoods);
            return null;
        }

        //TODO START HACK we need that BuildingBlueprint to create a new Building()
        b = (Building)System.Activator.CreateInstance(b.GetType());
        b.Sprite = Resources.Load<Sprite>(b.BuildingName);
        //END HACK


        b.CurrentProduction = b.ProductionCost;
        Globals.GridManager.EnableBuildingGhost(b);

        return b;
    }

    public void PlaceBuilding(Building b)
    {
        Buildings2.Add(b);
        CityManager.AddCoin(-b.CoinCost);
        b.Initialize();
    }

    public void AddWorkers(int val, Building b)
    {
        if (b.TryAddWorker(val))
        {
            Globals.CityManager.TryAddUnemployed(-val);
        }
        GuiManager.UpdateBuildingDetailGui(b);
    }

    public void HandleBuildingsOnEndTurn()
    {
        IncomeInventory = Buildings2.HandleBuildingsOnEndTurn(Inventory);
    }

    private void OnModeButtonClick(int index)
    {
        if (index < CurrentBuilding.BuildingEffects.Count)
        {
            CurrentBuilding.BuildingEffect = CurrentBuilding.BuildingEffects[index];
            CurrentBuilding.BuildingEffect?.Invoke(Inventory);
            GuiManager.UpdateBuildingDetailGui(CurrentBuilding);
        }
    }
}
