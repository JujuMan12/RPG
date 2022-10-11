using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour
{
    [HideInInspector] public InventoryItem inventoryItem;
    [HideInInspector] public UIInventoryList inventoryList;

    [Header("Icon")]
    [SerializeField] private Image itemIcon;

    private void Start()
    {
        itemIcon.sprite = inventoryItem.inventoryIcon;
    }

    public void SelectItem()
    {
        inventoryList.playerEquipment.currentEquipment[(int)inventoryItem.slotType] = inventoryItem;
    }
}
