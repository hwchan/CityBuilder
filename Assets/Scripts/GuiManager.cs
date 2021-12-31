using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GuiManager : MonoBehaviour
{

    public static GameObject Panel;
    public static GameObject InventoryPanel;
    public static GameObject ConstructionCostPanel;

    public static void UpdateBuildingDetailGui(Building building)
    {
        if (building == null)
            return;
        if (Panel == null)
        {
            Panel = GameObject.Find("LeftPanelBuilding");
            if (ConstructionCostPanel == null)
                ConstructionCostPanel = GameObject.Find("ConstructionCostPanel");
        }

        Panel.transform.Find("HeaderImage").GetComponent<Image>().sprite = building.Sprite;
        Panel.transform.Find("HeaderText").GetComponent<Text>().text = building.BuildingName.ToUpper();

        Panel.transform.Find("UpkeepText").GetComponent<Text>().text = "UPKEEP   G" + building.CoinUpkeep;
        Panel.transform.Find("LevelText").GetComponent<Text>().text = "LEVEL   " + building.Level;
        Panel.transform.Find("RequireText").GetComponent<Text>().text = "REQUIRE   " + building.MaterialsRequired;
        Panel.transform.Find("ProduceText").GetComponent<Text>().text = "PRODUCE   " + building.GetMaterialsProducedString();//.MaterialsProducedString;

        foreach (Transform t in ConstructionCostPanel.transform)
        {
            Good g = (Good)Enum.Parse(typeof(Good), t.name);

            //TODO: maybe make coin and time cost goods?
            if (g == Good.COIN)
            {
                t.gameObject.SetActive(true);
                t.Find("Text").GetComponent<Text>().text = building.CoinCost.ToString();
            }
            else if (g == Good.TIME)
            {
                t.gameObject.SetActive(true);
                t.Find("Text").GetComponent<Text>().text = building.ProductionCost.ToString();
            }
            else if (building.BuildingCost.ContainsKey(g))
            {
                t.gameObject.SetActive(true);
                t.Find("Text").GetComponent<Text>().text = building.BuildingCost[g].ToString();
            }
            else
            {
                t.gameObject.SetActive(false);
            }
        }

        Panel.transform.Find("WorkersText").GetComponent<Text>().text = $"{building.Workers} / {building.WorkerCapacity}";
    }

    public static void UpdateGui(GoodsCollection inventory)
    {
        if (InventoryPanel == null)
            InventoryPanel = GameObject.Find("InventoryPanel");

        foreach (KeyValuePair<Good, int> kvp in inventory)
        {
            var trn = InventoryPanel.transform.Find(kvp.Key.ToString().ToUpper());

            if (trn == null)
            {
                //TODO COIN is given as a reward, but is a good - should make all coin stuff into a good
                return;
            }

            var inv = trn.GetComponent<Text>();
            inv.text = kvp.Value.ToString();

            var val = Globals.BuildingManager.IncomeInventory[kvp.Key];
            if (val == 0)
                continue;

            //effect for showing the +/- for inventory
            var txt = trn.Find(trn.name + "_fade").GetComponent<Text>();
            txt.enabled = true;
            txt.CrossFadeAlpha(1, 0, false);

            if (val > 0)
            {
                txt.text = "+" + val;
                txt.color = Color.black;
            }
            else
            {
                txt.text = "-" + val;
                txt.color = Color.red;
            }
            txt.CrossFadeAlpha(0, 3, false);
        }
    }
}
