using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [HideInInspector] public enum EquipmentTypes { helmet, breastplate, pants, weapon, shield }
    [HideInInspector] public enum BodyPartsToHide { none, hair, head, top, topAndHands, bottom }
    [HideInInspector] public InventoryItem[] currentEquipment;
    [HideInInspector] public List<InventoryItem> collectedItems;

    [Header("Components")]
    [SerializeField] private Transform collectedItemsFolder;

    [Header("Body Parts To Hide")]
    [SerializeField] private GameObject[] hair;
    [SerializeField] private GameObject[] head;
    [SerializeField] private GameObject[] top;
    [SerializeField] private GameObject[] hands;
    [SerializeField] private GameObject[] bottom;

    private void Start()
    {
        collectedItems = new List<InventoryItem>();
        currentEquipment = new InventoryItem[5];
    }

    public void RemoveCurrentEquipment(int slot)
    {
        if (currentEquipment[slot] != null)
        {
            ChangeEquipmentState(currentEquipment[slot], false);
            currentEquipment[slot] = null;
        }
    }

    public void SetEquipment(InventoryItem equipment, int slot)
    {
        RemoveCurrentEquipment(slot);

        currentEquipment[slot] = equipment;
        ChangeEquipmentState(equipment, true);
    }

    private void ChangeEquipmentState(InventoryItem equipment, bool state)
    {
        switch (equipment.bodyPartToHide)
        {
            case BodyPartsToHide.hair:
                ChangeMeshState(hair, !state);
                break;
            case BodyPartsToHide.head:
                ChangeMeshState(head, !state);
                ChangeMeshState(hair, !state);
                break;
            case BodyPartsToHide.top:
                ChangeMeshState(top, !state);
                break;
            case BodyPartsToHide.topAndHands:
                ChangeMeshState(top, !state);
                ChangeMeshState(hands, !state);
                break;
            case BodyPartsToHide.bottom:
                ChangeMeshState(bottom, !state);
                break;
        }

        ChangeMeshState(equipment.meshes, state);
    }

    private void ChangeMeshState(GameObject[] meshes, bool state)
    {
        foreach (GameObject mesh in meshes)
        {
            mesh.SetActive(state);
        }
    }

    public void GetNewItem(InventoryItem item)
    {
        collectedItems.Add(item);
        item.transform.SetParent(collectedItemsFolder);
    }
}
