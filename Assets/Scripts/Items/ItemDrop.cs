using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    [SerializeField] float moveSpeed = 5f;

    BaseItem item;

    public void SetItem(BaseItem item)
    {
        this.item = item;
        spriteRenderer.sprite = item.itemSprite;
    }
}
