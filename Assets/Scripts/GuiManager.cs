using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiManager : MonoBehaviour {

    public static GameObject Panel;
    public static GameObject InventoryPanel;

    public static void UpdateBuildingDetailGui(Building building)
    {
        if (building == null)
            return;
        if (Panel == null)
            Panel = GameObject.Find("LeftPanelBuilding");

        Panel.transform.Find("HeaderImage").GetComponent<Image>().sprite = building.Sprite;
        Panel.transform.Find("HeaderText").GetComponent<Text>().text = building.BuildingName.ToUpper();

        Panel.transform.Find("UpkeepText").GetComponent<Text>().text = "UPKEEP   G" + building.CoinUpkeep;
        Panel.transform.Find("LevelText").GetComponent<Text>().text = "LEVEL   " + building.Level;
        Panel.transform.Find("RequireText").GetComponent<Text>().text = "REQUIRE   " + building.MaterialsRequired;
        Panel.transform.Find("ProduceText").GetComponent<Text>().text = "PRODUCE   " + building.MaterialsProduced;

        Panel.transform.Find("WOOD").GetComponent<Text>().text = building.BuildingCost[Good.Wood].ToString();
        Panel.transform.Find("STONE").GetComponent<Text>().text = building.BuildingCost[Good.Stone].ToString();
        Panel.transform.Find("IRON").GetComponent<Text>().text = building.BuildingCost[Good.Iron].ToString();
        Panel.transform.Find("TOOL").GetComponent<Text>().text = building.BuildingCost[Good.Tool].ToString();
        Panel.transform.Find("COIN").GetComponent<Text>().text = building.CoinCost.ToString();
        Panel.transform.Find("TIME").GetComponent<Text>().text = building.ProductionCost.ToString();

        Panel.transform.Find("WorkersText").GetComponent<Text>().text = $"{building.Workers} / {building.WorkerCapacity}";

        if (building.CurrentProduction > 0)
        {
            Panel.transform.Find("TimeLeftText").gameObject.SetActive(true);
            Panel.transform.Find("TimeLeftText").GetComponent<Text>().text = building.CurrentProduction.ToString();
        }
        else
        {
            Panel.transform.Find("TimeLeftText").gameObject.SetActive(false);
        }
        
    }

    public static void UpdateGui(GoodsCollection inventory)
    {
        if (InventoryPanel == null)
            InventoryPanel = GameObject.Find("InventoryPanel");

        foreach (KeyValuePair<Good, int> kvp in inventory)
        {
            var trn = InventoryPanel.transform.Find(kvp.Key.ToString().ToUpper());
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
