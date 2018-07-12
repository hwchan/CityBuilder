using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Building {

    public GameObject gObject;

    public string BuildingName { get; set; }
    public int Level { get; set; }
    public int Tier { get; set; }
    public int CoinCost { get; set; }
    public int CoinUpkeep { get; set; }
    public int ProductionCost { get; set; }
    public GoodsCollection BuildingCost { get; set; }
    public GoodsCollection MaterialsRequired { get; set; }
    public GoodsCollection MaterialsProduced { get; set; }
    public Action<GoodsCollection> BuildingEffect { get; set; }

    public void HandleGoods(GoodsCollection inventory, int numberOfBuildings)
    {
        //check required materials
        foreach(Good good in MaterialsRequired.Keys)
        {
            if(inventory[good] < MaterialsRequired[good] * numberOfBuildings)
                return;
        }

        //+- goods
        foreach (Good good in inventory.Keys.ToArray())
        {
            if (MaterialsRequired.ContainsKey(good))
                inventory[good] -= (MaterialsRequired[good] * numberOfBuildings);

            if (MaterialsProduced.ContainsKey(good))
                inventory[good] += (MaterialsProduced[good] * numberOfBuildings);
        }

        if(BuildingEffect != null)
            BuildingEffect(inventory);
    }
}
