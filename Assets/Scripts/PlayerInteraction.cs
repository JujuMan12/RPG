using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [HideInInspector] public bool canTakeLoot;
    [HideInInspector] private LootComponent loot;

    [Header("Components")]
    [SerializeField] private PlayerEquipment playerEquipment;

    private void Update()
    {
        if (canTakeLoot && Input.GetButtonDown("Activate"))
        {
            TakeLoot();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Loot"))
        {
            canTakeLoot = true;
            loot = collider.GetComponent<LootComponent>();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Loot"))
        {
            canTakeLoot = false;
            loot = null;
        }
    }

    private void TakeLoot()
    {
        playerEquipment.GetNewItem(loot.scriptedItem); //TODO: add random items
        Destroy(loot.gameObject);
        canTakeLoot = false;
    }
}
