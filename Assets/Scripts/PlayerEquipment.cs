using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [HideInInspector] private InventoryItem_Armor currentHelmet;
    [HideInInspector] private InventoryItem_Armor currentShirt;
    [HideInInspector] private InventoryItem_Armor currentPants;

    [Header("Armor")]
    [SerializeField] private int currentHelmetId;
    [SerializeField] private GameObject[] helmets;
    [SerializeField] private int currentChestId;
    [SerializeField] private GameObject[] chests;
    [SerializeField] private int currentArmsId;
    [SerializeField] private GameObject[] arms;
    [SerializeField] private int currentGauntletsId;
    [SerializeField] private GameObject[] gauntlets;
    [SerializeField] private int currentPantsId;
    [SerializeField] private GameObject[] pants;
    [SerializeField] private int currentBootsId;
    [SerializeField] private GameObject[] boots;

    private void FixedUpdate()
    {
        //SetArmor(helmets, currentHelmetId, currentHelmet);
        //SetArmor(chests, currentChestId, currentChest);
        //SetArmor(arms, currentArmsId, currentArms);
    }

    private void SetArmor(GameObject[] armors, int armorId, GameObject currentArmor)
    {
        if (currentArmor != armors[armorId])
        {
            currentArmor = armors[armorId];

            foreach (GameObject armor in armors)
            {
                armor.SetActive(false);
            }

            armors[armorId].SetActive(true);
        }
    }
}
