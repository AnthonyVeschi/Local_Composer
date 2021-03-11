using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    internal bool mouseLocked = true;

    public GameObject questCanvas; //is this canvas active? if so, keep the mouse unlocked.
    public GameObject dialogueCanvas; //is this canvas active? is so, keep the mouse unlocked.

    public float sensitivity_x = 1f;
    public float sensitivity_y = 1f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    void Update()
    {
        if (mouseLocked)
        {
            ///*
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            //*/

            /*
            yaw += sensitivity_x * Input.GetAxis("Mouse X");
            pitch += sensitivity_y * Input.GetAxis("Mouse Y");
            if (transform.parent != null) {
                transform.parent.transform.eulerAngles = new Vector3(-1 * pitch, yaw, 0.0f);
            } else {
                transform.eulerAngles = new Vector3(-1 * pitch, yaw, 0.0f);
            }
            */

        }
    }

    public void LockMouse()
    {
        if (questCanvas.activeSelf || dialogueCanvas.activeSelf) { return; }
        mouseLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UnlockMouse()
    {
        mouseLocked = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
