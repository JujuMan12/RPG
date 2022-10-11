using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [Header("General")]
    [SerializeField] public Sprite inventoryIcon;
    [SerializeField] public PlayerEquipment.EquipmentTypes slotType;
}
