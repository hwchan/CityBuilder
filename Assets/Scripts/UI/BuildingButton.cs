using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingButton : MonoBehaviour
{
    private Image _imageComponent;
    private Text _textComponent;

    private BuildingManager _buildingManager;
    private Building _building;

    public void InitializeBuildingButton(BuildingManager manager, Building building)
    {
        _buildingManager = manager;
        _building = building;

        _imageComponent = transform.Find("Image").GetComponent<Image>();
        _textComponent = transform.Find("Text").GetComponent<Text>();

        _imageComponent.rectTransform.sizeDelta = building.SpriteSize;
        _imageComponent.sprite = _building.Sprite;
        _textComponent.text = _building.Level + " " + _building.BuildingName.ToUpper();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        var b = Globals.BuildingManager.StartBuildingConstruction(_building);
    }

    public void UpdateBuildingButton()
    {
        _textComponent.text = _building.Level + " " + _building.BuildingName.ToUpper();
    }
}
