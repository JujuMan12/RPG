using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerEquipment playerEquipment;

    public void DrawInventory()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }

        foreach (InventoryItem itemData in playerEquipment.collectedItems)
        {
            //GameObject item = Instantiate(itemPrefab);
            //item.transform.SetParent(transform);

            //InventoryItemUI itemUI = item.GetComponent<InventoryItemUI>();
            //itemUI.inventoryItem = itemData;
        }
    }
}
