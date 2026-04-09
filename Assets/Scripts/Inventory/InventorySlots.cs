using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public BaseItem item;
    public int quantity;

    public Image itemImage;
    public TextMeshProUGUI quantityText;
    private void Awake()
    {
        //ClearSlot();
    }

    public void UpdateQuantity(int amount)
    {
        quantity += amount;
        quantityText.text = quantity.ToString();
        if (quantity <= 0)
        {
            ClearSlot();
        }
    }
    public void ClearSlot()
    {
        item = null;
        quantity = 0;
        quantityText.text = "";
        itemImage.sprite = null;
    }
}
