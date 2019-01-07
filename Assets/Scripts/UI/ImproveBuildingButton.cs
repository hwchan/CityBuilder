using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImproveBuildingButton : MonoBehaviour {

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        //_manager.AddCurrentBuildingLevel();
        Globals.BuildingManager.StartBuildingConstruction(Globals.BuildingManager.CurrentBuilding);
    }
}
