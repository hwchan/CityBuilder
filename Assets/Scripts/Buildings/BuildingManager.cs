using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour {

    public CityManager CityManager;

    public Building CurrentBuilding { get; private set; }

    public GameObject buildingButtonObject;
    public GameObject buildingListObject;

    public GoodsCollection Inventory { get; set; }
    public List<Building> Buildings { get; set; }

    public GoodsCollection IncomeInventory { get; set; }

    public Building this[string index]
    {
        get { return Buildings.Find(x => x.BuildingName.ToUpper() == index.ToUpper()); }
    }

    // Use this for initialization
    void Start ()
    {
        IncomeInventory = new GoodsCollection(0);
        Inventory = new GoodsCollection(0);

        Buildings = new List<Building>()
        {
            new Bakery(),
            new Bank(),
            new Barracks(),
            new Brewery(),
            new Castle(),
            new Chapel(),
            new ClayPit(),
            new CoalMine(),
            new ConstructionGuild(),
            new Courthouse(),
            new FishingWharf(),
            new FlaxFarm(),
            new GoldMine(),
            new Granary(),
            new House(),
            new HuntingLodge(),
            new IronMine(),
            new Leatherwork(),
            new Library(),
            new Lighthouse(),
            new Lumbermill(),
            new Market(),
            new Physician(),
            new PigFarm(),
            new Potter(),
            new Prison(),
            new Quarry(),
            new Shipyard(),
            new Smithy(),
            new Stables(),
            new SteelForge(),
            new Storehouse(),
            new Tavern(),
            new Theatre(),
            new TradeDepot(),
            new University(),
            new Watermill(),
            new Weaver(),
            new WheatFarm(),
            new Woodcutter(),
            new Workshop(),
        };
        
        foreach(Building b in Buildings)
        {
            b.gObject = GameObject.Find(b.BuildingName);
            b.gObject.SetActive(false);
            b.Sprite = Resources.Load<Sprite>(b.BuildingName);
            //b.gObject.SetActive(false);
            var btn = Instantiate(buildingButtonObject);
            btn.transform.SetParent(buildingListObject.transform);
            btn.transform.localScale = Vector3.one;
            var bb = btn.GetComponent<BuildingButton>();
            bb.InitializeBuildingButton(this, b);
            b.BuildingButton = bb;
        }
    }

    public Building SetCurrentBuilding(string buildingText)
    {
        CurrentBuilding = this[buildingText];
        //GuiManager.UpdateBuildingDetailGui(_sprite, _text, _buildingManager[_text]);
        return CurrentBuilding;
    }

    public int AddBuildingLevel(Building building)
    {
        if (building == null)
            building = CurrentBuilding;

        building.gObject.SetActive(true);
        building.Level++;
        //building.BuildingButton.UpdateBuildingGui();
        building.BuildingButton.OnClick();
        CityManager.AddCoin(-building.CoinCost);
        CityManager.SetIncome(CityManager.Income - building.CoinUpkeep);
        return building.Level;
    }

    public void StartBuildingConstruction()
    {
        CityManager.AddCoin(-CurrentBuilding.CoinCost);
        CurrentBuilding.Initialize();
        GuiManager.UpdateBuildingDetailGui(CurrentBuilding);
        //CurrentBuilding.BuildingButton.UpdateBuildingGui();
    }

    public void HandleBuildingsOnEndTurn()
    {
        int incomeGold = 0;
        var prevGoods = new GoodsCollection(Inventory);

        foreach (Building b in Buildings)
        {
            for (int i = 0; i < b.Level; i++)
            {
                b.HandleGoods(Inventory, 1);
                incomeGold -= b.CoinUpkeep;
            }

            if (b.CurrentProduction > 0 && --b.CurrentProduction <= 0)
                AddBuildingLevel(b);

            b.BuildingButton.UpdateBuildingButton();
        }

        CityManager.AddCoin(incomeGold);
        CityManager.SetIncome(incomeGold);
        GuiManager.UpdateGui(Inventory);
        GuiManager.UpdateBuildingDetailGui(CurrentBuilding);

        //calculate the difference in resources
        IncomeInventory = Inventory - prevGoods;
        Debug.Log(IncomeInventory);
    }
}
