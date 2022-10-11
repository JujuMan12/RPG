using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public PlayerEquipment playerEquipment;

    [Header("List")]
    [SerializeField] private GameObject itemPrefab;

    public void UpdateList()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }

        foreach (InventoryItem itemData in playerEquipment.collectedItems)
        {
            GameObject item = Instantiate(itemPrefab);
            item.transform.SetParent(transform);

            UIInventoryItem itemIcon = item.GetComponent<UIInventoryItem>();
            itemIcon.inventoryItem = itemData;
            itemIcon.inventoryList = this;
        }
    }
}
