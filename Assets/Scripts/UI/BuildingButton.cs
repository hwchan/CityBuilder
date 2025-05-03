using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingButton : MonoBehaviour
{
    private Image _imageComponent;
    private Text _textComponent;

    private BuildingManager _buildingManager;
    private BuildingBlueprint _blueprint;

    public void InitializeBuildingButton(BuildingManager manager, BuildingBlueprint blueprint)
    {
        _buildingManager = manager;
        _blueprint = blueprint;

        _imageComponent = transform.Find("Image").GetComponent<Image>();
        _textComponent = transform.Find("Text").GetComponent<Text>();

        _imageComponent.rectTransform.sizeDelta = blueprint.SpriteSize;
        _imageComponent.sprite = _blueprint.Sprite;
        _textComponent.text = _blueprint.BuildingName.ToUpper();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        var b = Globals.BuildingManager.StartBuildingConstruction(_blueprint);
    }
}
