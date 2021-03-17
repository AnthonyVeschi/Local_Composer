using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIdeaDialFunc : DialogueFunction
{
    public GameObject cubeBoi;
    public Transform cubeParent;

    public override void MyFunction()
    {
        Instantiate(cubeBoi, cubeParent);
    }
}
