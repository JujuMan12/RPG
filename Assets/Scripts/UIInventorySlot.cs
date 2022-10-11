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
        Sprite icon = player.currentEquipment[(int)slotType]?.icon;

        if (slot.sprite != icon)
        {
            slot.sprite = icon;
            slot.enabled = icon != null;
        }
    }

    public void RemoveItem()
    {
        player.RemoveCurrentEquipment((int)slotType);
    }
}
