using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] BaseItem item;

    [SerializeField] TileBase highlightTile; // A tile used to highlight the placement position
    [SerializeField] Tilemap mainTileMap;
    [SerializeField] Tilemap tempTileMap;

    Vector3Int highlightedTilePos;
    bool isHighlighted;
    private Vector3Int GetMouseOnGridPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseGridPosition = mainTileMap.WorldToCell(mouseWorldPosition);
        mouseGridPosition.z = 0;
        return mouseGridPosition;
    }
    private void Update()
    {
        if (item != null)
        {
            HighlightTile(item);
        }
    }
    private void HighlightTile(BaseItem tile)
    {
        Vector3Int mouseGridPosition = GetMouseOnGridPosition();
        if (highlightedTilePos != mouseGridPosition)
        {
            tempTileMap.SetTile(highlightedTilePos, tile: null);
            if (tile)
            {
                tempTileMap.SetTile(mouseGridPosition, highlightTile);
                highlightedTilePos = mouseGridPosition;
                isHighlighted = true;
            }
            else
            {
                isHighlighted = false;
            }
        }
    }
}
