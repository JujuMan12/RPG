using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour
{
    [HideInInspector] public InventoryItem inventoryItem;
    [HideInInspector] public UIInventoryList inventoryList;

    [Header("Item")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMPro.TMP_Text label;

    private void Start()
    {
        itemIcon.sprite = inventoryItem.icon;
        label.text = inventoryItem.label;
    }

    public void SelectItem()
    {
        inventoryList.playerEquipment.SetEquipment(inventoryItem, (int)inventoryItem.slotType);
    }
}
