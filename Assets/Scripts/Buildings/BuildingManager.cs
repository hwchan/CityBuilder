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
        return CurrentBuilding;
    }

    public int AddBuildingLevel(Building building)
    {
        if (building == null)
            building = CurrentBuilding;

        //building.gObject.SetActive(true);
        building.Level++;
        building.BuildingButton.OnClick();
        CityManager.AddCoin(-building.CoinCost);
        CityManager.SetIncome(CityManager.Income - building.CoinUpkeep);
        return building.Level;
    }

    public void StartBuildingConstruction(Building b)
    {
        CityManager.AddCoin(-b.CoinCost);
        b.Initialize();
        GuiManager.UpdateBuildingDetailGui(b);

        b.gObject.SetActive(true);
        b.gObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
        Instantiate(Globals.Time, b.gObject.transform);
    }

    private void CheckBuildingConstruction(Building b)
    {
        if (b.CurrentProduction > 0 && --b.CurrentProduction <= 0)
        {
            AddBuildingLevel(b);
            b.gObject.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(b.gObject.transform.Find("TIME(Clone)").gameObject);
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
        var prevGoods = new GoodsCollection(Inventory);

        foreach (Building b in Buildings)
        {
            for (int i = 0; i < b.Workers; i++)
            {
                b.HandleGoods(Inventory, 1);
                incomeGold -= b.CoinUpkeep;
            }

            CheckBuildingConstruction(b);

            b.BuildingButton.UpdateBuildingButton();
        }

        CityManager.AddCoin(incomeGold);
        CityManager.SetIncome(incomeGold);
        
        GuiManager.UpdateBuildingDetailGui(CurrentBuilding);

        //calculate the difference in resources
        IncomeInventory = Inventory - prevGoods;
        //Debug.Log(IncomeInventory);
        GuiManager.UpdateGui(Inventory);
    }
}
