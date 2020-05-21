using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum Terrain
{
    UNSET,
    GRASS,
    ROCK,
    FOREST,
    WATER,
    HIGHLAND,

    //TODO
    BEACH,
    SAND,
    SWAMP,
    DIRT,
    JUNGLE
}

public enum Doodad
{
    UNSET,
    EMPTY,
    TREE,
    BRIDGE_V,
    BRIDGE_H,
    WALL_TOWER,
    WALL_GATE,
    WALL,
}

//public class GridCell
//{
//    public Terrain Terrain { get; set; }
//    public Doodad Doodad { get; set; }
//    public bool HasWater { get; set; }
//    public Building Building { get; set; }
//    public SpriteRenderer Renderer { get; set; }
//    public GameObject GameObject { get; set; }
//    public bool SpriteOrigin { get; set; }  //top left origin of sprite

//    public void AssignBuilding(Building b)
//    {
//        Building = b;
//        Renderer.sprite = b.Sprite;
//        Renderer.transform.localPosition = (b.SpriteSize - Vector2.one) * .5f;
//        SpriteOrigin = true;
//        GameObject.name = $"{GameObject.name} {b.BuildingName}";
//    }

//    public void BlockNonOrigin(Building b)
//    {
//        Building = b;
//        Renderer.sprite = null;
//        Renderer.transform.localPosition = Vector2.zero;
//        SpriteOrigin = false;
//        GameObject.name = $"{GameObject.name} {b.BuildingName.Substring(0, 2)}";
//    }
//}

public class GridManager : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private GameObject _gridCellPrefab;
    [SerializeField] private GameObject _placement;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Vector2 _topLCoord = new Vector2(-10.5f, 11.5f);
    [SerializeField] private Vector2 _botRCoord = new Vector2(10.5f, -9.5f);

    private Building _selectedBuilding;
    public Dictionary<Vector2, GridCell> GridMapDict = new Dictionary<Vector2, GridCell>();

    private void Awake()
    {
        for (float y = 11.5f; y >= -9.5f; y--)
        {
            for (float x = -10.5f; x <= 10.5f; x++)
            {
                //var cell = new GridCell();
                //GridMapDict[new Vector2(x, y)] = cell;

                //var go = Instantiate(_placement, new Vector2(x, y), Quaternion.identity);
                //cell.Renderer = go.GetComponentInChildren<SpriteRenderer>();
                //cell.Renderer.sprite = null;
                //cell.GameObject = go;
                //go.transform.SetParent(_gridParent);
                //go.name = $"[{x}:{y}]";

                var go = Instantiate(_gridCellPrefab, new Vector2(x, y), Quaternion.identity);
                GridMapDict[new Vector2(x, y)] = go.GetComponent<GridCell>();
                go.transform.SetParent(_gridParent);
                go.name = $"[{x}:{y}]";
            }
        }
        //Debug.Log(GridMapDict.Count);
    }

    private void Update()
    {
        Vector3 v1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = Mathf.Floor(v1.x) + .5f;
        float y = Mathf.Floor(v1.y) + .5f;

        Vector2 v3 = new Vector2(x, y);

        if (v3.x >= _topLCoord.x && v3.x <= _botRCoord.x
            && v3.y <= _topLCoord.y && v3.y >= _botRCoord.y)
        {
            _placement.transform.position = v3;
        }

        if (Input.GetMouseButtonDown(0))
        {
            HandlePlaceBuilding(v3);
        }

        if (Input.GetMouseButtonDown(1))
        {
            DebugPrint();
        }
    }

    public void EnableBuildingGhost(Building b)
    {
        _selectedBuilding = b;
        _placement.SetActive(true);

        _sprite.sprite = _selectedBuilding.Sprite;
        _sprite.transform.localPosition = (_selectedBuilding.SpriteSize - Vector2.one) * .5f;
    }

    public void DisableBuildingGhost()
    {
        _placement.SetActive(false);
        _selectedBuilding = null;
        _sprite.sprite = null;
    }

    private void HandlePlaceBuilding(Vector2 v3)
    {
        if (GridMapDict.ContainsKey(v3) && _selectedBuilding != null)
        {
            //check the size of the building to see if its blocked
            for (int x = 0; x < _selectedBuilding.SpriteSize.x; x++)
            {
                for (int y = 0; y < _selectedBuilding.SpriteSize.y; y++)
                {
                    //Debug.Log(new Vector2(v3.x + x, v3.y + y));
                    if (GridMapDict[new Vector2(v3.x + x, v3.y + y)].Building != null)
                    {
                        Debug.LogError($"{v3.x + x}:{v3.y + y} BLOCKED");
                        return;
                    }
                }
            }

            GridMapDict[v3].AssignBuilding(_selectedBuilding);

            //block non origin cells
            for (int i = 0; i < _selectedBuilding.SpriteSize.x; i ++)
            {
                for (int j = 0; j < _selectedBuilding.SpriteSize.y; j++)
                {
                    var nonOrigin = v3 + new Vector2(i, j);
                    var cell = GridMapDict[nonOrigin];
                    if (cell.Building == null)
                        cell.BlockNonOrigin(_selectedBuilding);
                }
            }

            DisableBuildingGhost();
        }
    }

    private void DebugPrint()
    {
        var sb = new StringBuilder();
        foreach (var kvp in GridMapDict)
        {
            if (kvp.Value.Building != null)
            {
                sb.AppendLine($"{kvp.Key.x},{kvp.Key.y}:  {kvp.Value.Building.BuildingName}");
            }
        }
        Debug.LogError(sb.ToString());
    }
}
