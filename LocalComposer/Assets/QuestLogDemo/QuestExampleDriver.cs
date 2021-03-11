using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestExampleDriver : MonoBehaviour
{
    private QuestA a;
    private QuestB b;
    private QuestC c;

    private void Start()
    {
        a = gameObject.GetComponent<QuestA>();
        b = gameObject.GetComponent<QuestB>();
        c = gameObject.GetComponent<QuestC>();
    }

    void Update()
    {
        if (Time.time >= 3 && !a.activated) { a.Activate(); }
        if (Time.time >= 5 && !b.activated) { b.Activate(); }
        if (Time.time >= 7 && !c.activated) { c.Activate(); }
        if (Time.time >= 9 && !a.completed) { a.Complete(); }
        if (Time.time >= 11 && !b.completed) { b.Complete(); }
        if (Time.time >= 13 && !c.completed) { c.Complete(); }
    }
}
