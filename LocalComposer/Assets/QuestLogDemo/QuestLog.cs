using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    private GameObject slotOne;
    private GameObject slotTwo;
    private GameObject slotThree;
    private GameObject slotFour;
    private GameObject slotFive;

    private List<GameObject> slots;

    private int nextAvailableSlot;

    private void Start()
    {
        slotOne = transform.GetChild(0).gameObject;
        slotTwo = transform.GetChild(1).gameObject;
        slotThree = transform.GetChild(2).gameObject;
        slotFour = transform.GetChild(3).gameObject;
        slotFive = transform.GetChild(4).gameObject;

        slots = new List<GameObject>();
        slots.Add(slotOne);
        slots.Add(slotTwo);
        slots.Add(slotThree);
        slots.Add(slotFour);
        slots.Add(slotFive);

        nextAvailableSlot = 0;

        gameObject.SetActive(false);
    }

    public void IncrementNextAvailableSlot()
    {
        nextAvailableSlot++;
    }

    public GameObject GetNextAvailableSlot()
    {
        GameObject result = slots[nextAvailableSlot];
        IncrementNextAvailableSlot();
        return result;
    }
}
