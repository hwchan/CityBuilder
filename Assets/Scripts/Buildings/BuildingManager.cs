using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public CityManager CityManager;

    public BuildingBlueprint CurrentBuilding { get; private set; }

    public GameObject buildingButtonObject;
    public GameObject buildingListObject;

    public GoodsCollection Inventory { get; set; }
    //public BuildingsCollection Buildings { get; set; }  //TODO
    public BuildingsCollection2 Buildings { get; set; }

    //TODO this shouldn't be here
    public GoodsCollection IncomeInventory { get; set; }

    [SerializeField] private Button[] _modeButtons = new Button[4];

    public static BuildingManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IncomeInventory = new GoodsCollection(0);
        Inventory = new GoodsCollection(100);
        GuiManager.Instance.UpdateInventory(Inventory);
        Buildings = new BuildingsCollection2();

        Inventory.OnCollectionChange += (collection, args) => 
        {
            //Debug.Log(args.Good + (args.Value > 0 ? ": +" + args.Value : ": " + args.Value));
            GuiManager.Instance.UpdateInventory(Inventory);
        };

        //TODO
        Buildings = new BuildingsCollection2();
        foreach (var key in Buildings.Keys)
        {
            //Building b = Buildings[key];
            var b = Buildings.GetBlueprint(key);

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

    public BuildingBlueprint SetCurrentBuilding(BuildingBlueprint b)
    {
        CurrentBuilding = b;
        for (int i = 0; i < _modeButtons.Length; i++)
        {
            _modeButtons[i].gameObject.SetActive(i <= CurrentBuilding.BuildingEffects.Count - 1);
        }
        return CurrentBuilding;
    }

    public void StartBuildingConstruction(BuildingBlueprint blueprint)
    {
        var b = new Building(blueprint);

        var missingGoods = b.TryStartConstruction(Inventory);
        if (missingGoods.Count > 0)
        {
            Globals.PopupText.PopUp("Missing - " + missingGoods);
            Debug.Log("Missing - " + missingGoods);
            return;
        }

        ////TODO START HACK we need that BuildingBlueprint to create a new Building()
        //b = (Building)System.Activator.CreateInstance(b.GetType());
        //b.Sprite = Resources.Load<Sprite>(b.BuildingName);
        ////END HACK

        b.CurrentProduction = b.Blueprint.ProductionCost;
        Globals.GridManager.EnableBuildingGhost(b);
        Buildings.Add(b);

        CityManager.AddCoin(-b.Blueprint.CoinCost);
        b.Initialize();
        GuiManager.Instance.UpdateBuildingDetails(blueprint);
    }

    public void HandleBuildingsOnEndTurn()
    {
        IncomeInventory = Buildings.HandleBuildingsOnEndTurn(Inventory);
    }

    private void OnModeButtonClick(int index)
    {
        if (index < CurrentBuilding.BuildingEffects.Count)
        {
            foreach (var b in Buildings[CurrentBuilding.BuildingName])
            {
                b.BuildingEffect = CurrentBuilding.BuildingEffects[index];
                b.BuildingEffect?.Invoke(Inventory);
                GuiManager.Instance.UpdateBuildingDetails(CurrentBuilding);
            }
        }
    }
}
