using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImproveBuildingButton : MonoBehaviour {

    private BuildingManager _manager;

    void Start()
    {
        _manager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        //_manager.AddCurrentBuildingLevel();
        _manager.StartBuildingConstruction();
    }
}
