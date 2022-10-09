using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [HideInInspector] public InventoryItem inventoryItem;
    [HideInInspector] public UIInventoryList inventoryList;

    private void Start()
    {
        GetComponent<Image>().sprite = inventoryItem.inventoryIcon;
    }
}
