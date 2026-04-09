using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] BaseItem item;

    [SerializeField] TileBase highlightTile; // A tile used to highlight the placement position
    [SerializeField] Tilemap mainTileMap;
    [SerializeField] Tilemap tempTileMap;

    Vector3Int playerPosition;
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
        playerPosition = mainTileMap.WorldToCell(transform.position);
        if (item != null)
        {
            HighlightTile(item);
        }
    }
    private void HighlightTile(BaseItem currenTile)
    {
        Vector3Int mouseGridPosition = GetMouseOnGridPosition();
        if (highlightedTilePos != mouseGridPosition)
        {
            tempTileMap.SetTile(highlightedTilePos, tile: null);

            TileBase tile = mainTileMap.GetTile(mouseGridPosition);
            if (InRange(playerPosition, mouseGridPosition, currenTile.range))
            {
                if (CheckItemType(mainTileMap.GetTile<BaseTile>(mouseGridPosition), currenTile))
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
    private bool InRange(Vector3Int playerPosition, Vector3Int target, Vector2Int range)
    {
        Vector3Int distance = playerPosition - target;
        if (Mathf.Abs(distance.x) <= range.x || Mathf.Abs(distance.y) <= range.y)
        {
            return true;
        }
        return false;
    }
    public bool CheckItemType(BaseTile tile, BaseItem currentItem)
    {
        if (currentItem.itemType == ItemType.Placeable)
        {
            if (!tile)
                return false;
        }
        else if (currentItem.itemType == ItemType.Tool)
        {
            if (tile)
            {
                if (tile.item.actionType == currentItem.actionType)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
