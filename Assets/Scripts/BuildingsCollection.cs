//using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//unused atm
public class BuildingsCollection : Dictionary<Building, int> {

    public BuildingsCollection()
    {

    }

    public BuildingsCollection(int amount)
    {

    }

    //public void HandleGoodsForAllBuildings(GoodsCollection inventory)
    //{
    //    foreach(KeyValuePair<Building, int> kvp in this)
    //    {
    //        if (kvp.Value == 0)
    //            continue;

    //        kvp.Key.HandleGoods(inventory, kvp.Value);
    //    }
    //    return;
    //}

}
