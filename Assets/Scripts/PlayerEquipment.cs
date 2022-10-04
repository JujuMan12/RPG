using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [HideInInspector] private GameObject currentBoots;

    [Header("Armor")]
    [SerializeField] private int currentBootsId;
    [SerializeField] private GameObject[] boots;

    private void FixedUpdate()
    {
        SetArmor(boots, currentBootsId, currentBoots);
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
