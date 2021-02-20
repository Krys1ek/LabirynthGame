using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float mouseSencivity = 100f;
    public Transform playerBody = null;
    public float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        playerBody = transform.parent;

        float MouseX = Input.GetAxis("Mouse X") * mouseSencivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSencivity * Time.deltaTime;

        xRotation -= MouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

        playerBody.Rotate(Vector3.up * MouseX);
    }
}
