using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem_Armor : InventoryItem
{
    [Header("Armor")]
    [SerializeField] private GameObject armor;
    [SerializeField] private bool shouldHideHead;
    [SerializeField] private bool shouldHideTop;
    [SerializeField] private bool shouldHideBottom;
}
