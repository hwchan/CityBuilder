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

        Panel.transform.FindChild("HeaderImage").GetComponent<Image>().sprite = building.Sprite;
        Panel.transform.FindChild("HeaderText").GetComponent<Text>().text = building.BuildingName.ToUpper();

        Panel.transform.FindChild("UpkeepText").GetComponent<Text>().text = "UPKEEP   G" + building.CoinUpkeep;
        Panel.transform.FindChild("LevelText").GetComponent<Text>().text = "LEVEL   " + building.Level;
        Panel.transform.FindChild("RequireText").GetComponent<Text>().text = "REQUIRE   " + building.MaterialsRequired;
        Panel.transform.FindChild("ProduceText").GetComponent<Text>().text = "PRODUCE   " + building.MaterialsProduced;

        Panel.transform.FindChild("WOOD").GetComponent<Text>().text = building.BuildingCost[Good.Wood].ToString();
        Panel.transform.FindChild("STONE").GetComponent<Text>().text = building.BuildingCost[Good.Stone].ToString();
        Panel.transform.FindChild("IRON").GetComponent<Text>().text = building.BuildingCost[Good.Iron].ToString();
        Panel.transform.FindChild("TOOL").GetComponent<Text>().text = building.BuildingCost[Good.Tool].ToString();
        Panel.transform.FindChild("COIN").GetComponent<Text>().text = building.CoinCost.ToString();
        Panel.transform.FindChild("TIME").GetComponent<Text>().text = building.ProductionCost.ToString();

        if (building.CurrentProduction > 0)
        {
            Panel.transform.FindChild("TimeLeftText").gameObject.SetActive(true);
            Panel.transform.FindChild("TimeLeftText").GetComponent<Text>().text = building.CurrentProduction.ToString();
        }
        else
        {
            Panel.transform.FindChild("TimeLeftText").gameObject.SetActive(false);
        }
        
    }

    public static void UpdateGui(GoodsCollection inventory)
    {
        if (InventoryPanel == null)
            InventoryPanel = GameObject.Find("InventoryPanel");

        foreach (KeyValuePair<Good, int> kvp in inventory)
        {
            var inv = InventoryPanel.transform.FindChild(kvp.Key.ToString().ToUpper()).GetComponent<Text>();
            inv.text = kvp.Value.ToString();
        }
    }
}
