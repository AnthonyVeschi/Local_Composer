using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestClass : MonoBehaviour
{
    public GameObject log; //the canvas that holds the text elements
    private QuestLog logScript; //the script that manages the log slots

    [SerializeField] private string logString; //the text that goes in the quest log
    [SerializeField] private string logStringStrikethrough; //the text that goes in the quest log w/ strikethrough

    [SerializeField] private GameObject logSlot; //the slot in the log that belongs to this quest

    //some bools to get whether or not the quest has been activated / completed
    public bool activated = false;
    public bool completed = false;

    private void Start()
    {
        logScript = log.GetComponent<QuestLog>();
    }

    public void Activate()
    {
        GameObject slot = logScript.GetNextAvailableSlot();
        Text text = slot.GetComponent<Text>();
        while (text.text != "")
        {
            Debug.Log("QUEST TRIED TO TAKE UNAVAILABLE SLOT");
            slot = logScript.GetNextAvailableSlot();
            text = slot.GetComponent<Text>();
        }

        text.text = logString;
        logSlot = slot;

        activated = true;
    }

    public void Complete()
    {
        Text text = logSlot.GetComponent<Text>();
        text.text = logStringStrikethrough;

        completed = true;
    }
}
