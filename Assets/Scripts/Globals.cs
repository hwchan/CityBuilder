using System;
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
    public GameObject GameEventManagerObj;
    public GameObject MissionManagerObj;
    public GameObject GridManagerObj;

    public GameObject TimeObject;
    public GameObject TextObject;
    public GameObject ExpiryObject;

    [SerializeField] private GameObject _transitionAnimationPanel;
    [SerializeField] private Camera _camera;

    public GameObject[] GoodsObjects;

    public static NextTurnModal NextTurnModal;
    public static PopupText PopupText;
    public static BuildingManager BuildingManager;
    public static CityManager CityManager;
    public static GuiManager GuiManager;
    public static GameEventManager GameEventManager;
    public static MissionManager MissionManager;
    public static GridManager GridManager;

    public static GameObject Time;
    public static GameObject Text;
    public static GameObject Expiry;

    public static GameObject TransitionAnimationPanel;
    public static Camera Camera;

    public static Dictionary<Good, GameObject> Goods = new Dictionary<Good, GameObject>();

    private void Start()
    {
        NextTurnModal = ModalPanelObj.GetComponent<NextTurnModal>();
        PopupText = PopupPanelObj.GetComponent<PopupText>();
        BuildingManager = BuildingMangerObj.GetComponent<BuildingManager>();
        CityManager = CityManagerObj.GetComponent<CityManager>();
        GuiManager = GuiManagerObj.GetComponent<GuiManager>();
        GameEventManager = GameEventManagerObj.GetComponent<GameEventManager>();
        MissionManager = MissionManagerObj.GetComponent<MissionManager>();
        GridManager = GridManagerObj.GetComponent<GridManager>();

        Time = TimeObject;
        Text = TextObject;
        Expiry = ExpiryObject;

        TransitionAnimationPanel = _transitionAnimationPanel;
        Camera = _camera;

        foreach (var g in GoodsObjects)
        {
            if (g == null)
                continue;
            var e = (Good)Enum.Parse(typeof(Good), g.name);
            Goods.Add(e, g);
        }
        
    }
}
