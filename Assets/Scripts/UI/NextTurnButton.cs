using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextTurnButton : MonoBehaviour {

    private BuildingManager _manager;

	void Start () {
        _manager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
    void OnClick()
    {
        _manager.DoWork();
    }
}
