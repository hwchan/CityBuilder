using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextTurnButton : MonoBehaviour {

    private BuildingManager _manager;
    private CityManager _cityManager;

	void Start () {
        _manager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        _cityManager = GameObject.Find("CityManager").GetComponent<CityManager>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
    void OnClick()
    {
        _manager.HandleBuildingsOnEndTurn();
        _cityManager.AddTurns(1);
    }
}
