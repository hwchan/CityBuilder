using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWorkersButton : MonoBehaviour
{
    public int value;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Globals.BuildingManager.AddWorkers(value, Globals.BuildingManager.CurrentBuilding);
    }
}
