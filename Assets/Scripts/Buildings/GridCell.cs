using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] SpriteRenderer _buildingRenderer;
    [SerializeField] Collider2D _buildingCollider;

    //public Terrain Terrain { get; set; }
    //public Doodad Doodad { get; set; }
    //public bool HasWater { get; set; }
    public Building Building { get; private set; }
    //public SpriteRenderer Renderer { get; set; }
    //public GameObject GameObject { get; set; }
    public bool SpriteOrigin { get; set; }  //top left origin of sprite

    public void AssignBuilding(Building b)
    {
        Building = b;
        _buildingRenderer.sprite = b.Sprite;
        _buildingRenderer.transform.localPosition = (b.SpriteSize - Vector2.one) * .5f;
        SpriteOrigin = true;
        gameObject.name = $"{gameObject.name} {b.BuildingName}";
    }

    public void BlockNonOrigin(Building b)
    {
        Building = b;
        _buildingRenderer.sprite = null;
        _buildingRenderer.transform.localPosition = Vector2.zero;
        SpriteOrigin = false;
        gameObject.name = $"{gameObject.name} {b.BuildingName.Substring(0, 2)}";
    }
}