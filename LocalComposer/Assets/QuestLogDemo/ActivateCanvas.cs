using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCanvas : MonoBehaviour
{
    public GameObject questCanvas;
    public GameObject cam;
    MouseLook mouseLook;

    private void Start()
    {
        mouseLook = cam.GetComponent<MouseLook>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (questCanvas.activeSelf)
            {
                questCanvas.SetActive(false);
                mouseLook.LockMouse();
            }
            else
            {
                questCanvas.SetActive(true);
                mouseLook.UnlockMouse();
            }
        }
    }
}
