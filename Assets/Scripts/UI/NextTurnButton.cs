using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextTurnButton : MonoBehaviour {

	void Start () {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
    void OnClick()
    {
        Globals.BuildingManager.HandleBuildingsOnEndTurn();
        Globals.CityManager.AddTurns(1);
        //TODO: should this be kept?
        //Globals.NextTurnModal.ShowNextTurnModal();
    }
}
