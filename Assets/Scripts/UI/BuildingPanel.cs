using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] private Image _headerImage;
    [SerializeField] private Text _headerText;

    [SerializeField] private Text _upkeepText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text requireText;
    [SerializeField] private Text _produceText;

    public void UpdateBuildingDetails(BuildingBlueprint building)
    {
        if (building == null)
        {
            return;
        }

        _headerImage.sprite = building.Sprite;
        _headerText.text = building.BuildingName.ToUpper();

        _upkeepText.text = "UPKEEP   G" + building.CoinUpkeep;

        int level = Globals.BuildingManager.Buildings[building.BuildingName].Sum(b => b.Level);
        _levelText.text = "LEVEL   " + level;
        requireText.text = "REQUIRE   " + building.MaterialsRequired;
        _produceText.text = "PRODUCE   " + building.GetMaterialsProducedString();
    }
}
