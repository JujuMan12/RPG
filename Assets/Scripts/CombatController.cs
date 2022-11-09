using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int comboLength = 3; //TODO: relocate to weapon
    [SerializeField] private int attackId;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private void Update()
    {

    }
}
