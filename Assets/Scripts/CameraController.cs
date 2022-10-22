using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector] private Vector2 cameraInput;
    [HideInInspector] private float cameraPitch;

    [Header("Camera")]
    [SerializeField] private Transform verticalRotation;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float maxVPitchPos = 30f;
    [SerializeField] private float maxVPitchNeg = -60f;

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        cameraInput.x = Input.GetAxis("Mouse X"); //TODO: implement controller
        cameraInput.y = Input.GetAxis("Mouse Y");
        cameraInput *= rotationSpeed * Time.deltaTime;

        cameraPitch = Mathf.Clamp(cameraPitch - cameraInput.y, maxVPitchNeg, maxVPitchPos);

        transform.Rotate(Vector3.up, cameraInput.x);
        verticalRotation.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }
}
