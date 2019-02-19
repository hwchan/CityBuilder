using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public GameObject ModalPanelObj;
    public GameObject PopupPanelObj;
    public GameObject BuildingMangerObj;
    public GameObject CityManagerObj;
    public GameObject GuiManagerObj;

    public GameObject TimeObject;
    public GameObject TextObject;

    public static NextTurnModal NextTurnModal;
    public static PopupText PopupText;
    public static BuildingManager BuildingManager;
    public static CityManager CityManager;
    public static GuiManager GuiManager;

    public static GameObject Time;
    public static GameObject Text;

    private void Start()
    {
        NextTurnModal = ModalPanelObj.GetComponent<NextTurnModal>();
        PopupText = PopupPanelObj.GetComponent<PopupText>();
        BuildingManager = BuildingMangerObj.GetComponent<BuildingManager>();
        CityManager = CityManagerObj.GetComponent<CityManager>();
        GuiManager = GuiManagerObj.GetComponent<GuiManager>();

        Time = TimeObject;
        Text = TextObject;
    }
}
