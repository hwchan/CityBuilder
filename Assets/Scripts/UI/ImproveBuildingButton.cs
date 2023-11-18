using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImproveBuildingButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;

    void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Globals.BuildingManager.ImproveBuilding(Globals.BuildingManager.CurrentBuilding);
    }

    public void SetState(bool isEnabled)
    {
        _button.interactable = isEnabled;
        _text.text = isEnabled ? "IMPROVE" : "IMPROVING";
    }
}
