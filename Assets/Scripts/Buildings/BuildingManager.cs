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
    public BuildingsCollection Buildings { get; set; }

    //TODO this shouldn't be here
    public GoodsCollection IncomeInventory { get; set; }

    [SerializeField] private Button[] _modeButtons = new Button[4];

    void Start ()
    {
        IncomeInventory = new GoodsCollection(0);
        Inventory = new GoodsCollection(100);
        GuiManager.UpdateGui(Inventory);
        Buildings = new BuildingsCollection();

        Inventory.OnCollectionChange += (collection, args) => 
        {
            //Debug.Log(args.Good + (args.Value > 0 ? ": +" + args.Value : ": " + args.Value));
            GuiManager.UpdateGui(Inventory);
        };

        foreach (var key in Buildings.Keys)
        {
            Building b = Buildings[key];
            b.Sprite = Resources.Load<Sprite>(b.BuildingName);
            //b.gObject = GameObject.Find(b.BuildingName);
            //b.gObject.SetActive(false);

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

    public Building SetCurrentBuilding(BuildingEnum b)
    {
        CurrentBuilding = Buildings[b];
        for (int i = 0; i < _modeButtons.Length; i++)
        {
            _modeButtons[i].gameObject.SetActive(i <= CurrentBuilding.BuildingEffects.Count - 1);
        }
        return CurrentBuilding;
    }

    public int AddBuildingLevel(Building building)
    {
        if (building == null)
            building = CurrentBuilding;

        building.AddLevel(1);
        building.BuildingButton.OnClick();
        CityManager.AddCoin(-building.CoinCost);
        CityManager.SetIncome(CityManager.Income - building.CoinUpkeep);
        return building.Level;
    }

    public void StartBuildingConstruction(Building b)
    {
        var missingGoods = b.TryStartConstruction(Inventory);
        if (missingGoods.Count > 0)
        {
            Globals.PopupText.PopUp("Missing - " + missingGoods);
            Debug.Log("Missing - " + missingGoods);
            return;
        }

        //TODO:
        Globals.GridManager.EnableBuildingGhost(b);

        CityManager.AddCoin(-b.CoinCost);
        b.Initialize();
        GuiManager.UpdateBuildingDetailGui(b);

        //b.gObject.SetActive(true);
        //b.gObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
        //Instantiate(Globals.Time, b.gObject.transform);
    }

    private void CheckBuildingConstruction(Building b)
    {
        if (b.CurrentProduction > 0 && (b.CurrentProduction -= Globals.CityManager.Production) <= 0)
        {
            //TransitionAnimation.CreateImage(b.Sprite, b.gObject.transform.position, b.gObject.transform.localScale, b.gObject.transform.localScale*2, .75f);
            AddBuildingLevel(b);
            //b.gObject.GetComponent<SpriteRenderer>().color = Color.white;
            //Destroy(b.gObject.transform.Find("TIME(Clone)").gameObject);
        }
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
        int incomeGold = 0;
        int culture = 0;
        var prevGoods = new GoodsCollection(Inventory);

        foreach (var key in Buildings.Keys)
        {
            var b = Buildings[key];
            b.HandleGoods(Inventory);
            incomeGold -= b.GetUpkeep(Inventory);
            CheckBuildingConstruction(b);
            b.BuildingButton.UpdateBuildingButton();
            culture += b.Culture;
        }

        CityManager.AddCoin(incomeGold);
        CityManager.SetIncome(incomeGold);
        CityManager.SetCulture(culture);
        
        GuiManager.UpdateBuildingDetailGui(CurrentBuilding);

        //calculate the difference in resources
        IncomeInventory = new GoodsCollection(Inventory);
        IncomeInventory.Subtract(prevGoods);
        //GuiManager.UpdateGui(Inventory);  //NO NEED WITH OnCollectionChange HOHOHO 
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
