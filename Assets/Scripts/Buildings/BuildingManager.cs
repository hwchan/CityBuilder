using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour {

    public GameObject buildingButtonObject;
    public GameObject buildingListObject;

    public GoodsCollection Inventory { get; set; }
    public List<Building> Buildings { get; set; }

    public Building this[string index]
    {
        get { return Buildings.Find(x => x.BuildingName.ToUpper() == index.ToUpper()); }
    }

    // Use this for initialization
    void Start ()
    {
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
            //b.gObject.SetActive(false);
            var btn = Instantiate(buildingButtonObject);
            btn.transform.SetParent(buildingListObject.transform);
            btn.transform.localScale = Vector3.one;
            btn.GetComponent<BuildingButton>().InitializeBuildingButton(this, b.BuildingName, b.BuildingName);
        }
        Debug.Log(Buildings.Count);
    }

    public void DoWork()
    {
        foreach (Building b in Buildings)
        {
            for(int i = 0; i < b.Level; i++)
                b.HandleGoods(Inventory, 1);
        }

        //foreach (var i in Inventory)
        //{
        //    Debug.Log(i.Key + ": " + i.Value);
        //}
    }

    void OnGUI()
    {
        int j = 0;
        foreach (KeyValuePair<Good, int> kvp in Inventory)
        {
            if (j == 4)
                j++;
            if (j == 7)
                j++;
            if (j == 13)
                j++;
            GUI.Label(new Rect(50 + j++ * 32f, 802, 100, 90), kvp.Value.ToString(), new GUIStyle { fontSize = 14 });
        }
    }
}
