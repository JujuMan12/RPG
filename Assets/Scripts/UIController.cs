using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [HideInInspector] private bool inventoryState;

    [Header("UI Elements")]
    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] private GameObject lootTip;

    [Header("Components")]
    [SerializeField] private PlayerInteraction playerInteraction;

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryState = SetWindowState(inventoryWindow, !inventoryState);
        }
    }

    private void FixedUpdate()
    {
        SetTipState(lootTip, playerInteraction.canTakeLoot);
    }

    private bool SetWindowState(GameObject window, bool state)
    {
        window.SetActive(state);

        if (state)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        return state;
    }

    private void SetTipState(GameObject tip, bool state)
    {
        tip.SetActive(state);
    }
}
