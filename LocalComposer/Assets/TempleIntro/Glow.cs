using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public Material mat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") { return; }
        mat.SetColor("_EMISSION", new Color(1, 1, 0));
        mat.EnableKeyword("_EMISSION");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") { return; }
        mat.SetColor("_EMISSION", new Color(0, 0, 0));
        mat.DisableKeyword("_EMISSION");
    }
}
