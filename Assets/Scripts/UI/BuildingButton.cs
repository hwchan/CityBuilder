using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

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

        _imageComponent.rectTransform.sizeDelta = _blueprint.SpriteSize;
        _imageComponent.sprite = _blueprint.Sprite;

        int level = BuildingManager.Instance.Buildings[_blueprint.BuildingName].Sum(b => b.Level);
        _textComponent.text = level + " " + _blueprint.BuildingName.ToUpper();

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        GuiManager.Instance.UpdateBuildingDetails(_blueprint);
        UpdateBuildingButton();

        _buildingManager.SetCurrentBuilding(_blueprint);
    }

    public void UpdateBuildingButton()
    {
        int level = BuildingManager.Instance.Buildings[_blueprint.BuildingName].Sum(b => b.Level);
        _textComponent.text = level + " " + _blueprint.BuildingName.ToUpper();
    }
}
