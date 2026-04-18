using System.Collections;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    [SerializeField] float moveSpeed = 5f;

    BaseItem item;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    public void SetItem(BaseItem item)
    {
        this.item = item;
        spriteRenderer.sprite = item.itemSprite;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryPanel inventory = UIManager.Instance.registeredPanels.Find(p => p.name == "InventoryPanel").GetComponent<InventoryPanel>();
            if (inventory != null)
            {
                if (inventory.CanAddItem(item))
                {
                    inventory.AddItem(item);
                    StartCoroutine(MoveAndCollect(other.transform));
                }
                else
                {
                    Debug.Log("Inventory is full!");
                    return;
                }
            }
        }
    }
    private IEnumerator MoveAndCollect(Transform target)
    {
        Destroy(boxCollider);

        while (transform.position != target.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return 0;
        }
        Destroy(gameObject);
    }
}
