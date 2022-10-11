using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] public Sprite icon;
    [SerializeField] public string label;
    [SerializeField] public PlayerEquipment.EquipmentTypes slotType;

    [Header("Visual")]
    [SerializeField] public PlayerEquipment.BodyPartsToHide bodyPartToHide;
    [SerializeField] public GameObject[] meshes;
}
