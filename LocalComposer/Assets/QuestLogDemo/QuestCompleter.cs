using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleter : MonoBehaviour
{
    public GameObject npc; //the character on which the quest is hosted
    public NPC oldDialogue; //the interaction that we want to turn off
    public NPC newDialogue; //the interaction that we want to turn on

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            oldDialogue.enabled = false;
            newDialogue.enabled = true;
            Destroy(gameObject);
        }
    }
}
