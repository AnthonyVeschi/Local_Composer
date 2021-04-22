using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embers : MonoBehaviour
{
    ParticleSystem sys;
    ParticleSystemRenderer rend;

    public Material yellow;
    public Material green;
    public Material red;


    private void Start()
    {
        sys = gameObject.GetComponent<ParticleSystem>();
        rend = gameObject.GetComponent<ParticleSystemRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            EmitYellow();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            EmitGreen();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            EmitRed();
        }
    }

    public void EmitYellow()
    {
        rend.material = yellow;
        sys.Play();
    }

    public void EmitGreen()
    {
        rend.material = green;
        sys.Play();
    }

    public void EmitRed()
    {
        rend.material = red;
        sys.Play();
    }
}
