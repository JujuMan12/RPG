using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerEquipment player;

    [Header("Icon")]
    [SerializeField] private Image slot;
    [SerializeField] private PlayerEquipment.EquipmentTypes slotType;

    private void Update()
    {
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        Sprite inventoryIcon = player.currentEquipment[(int)slotType]?.inventoryIcon;

        if (slot.sprite != inventoryIcon)
        {
            slot.sprite = inventoryIcon;
        }

        slot.enabled = slot.sprite != null;
    }
}
