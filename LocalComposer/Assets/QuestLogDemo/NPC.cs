using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public GameObject interactionPrompt; //UI text, "PRESS F TO INTERACT", displays when player within radius
    public GameObject interactionMarker; //Exclamation Mark above NPC's head, indicates interaction can be had

    bool canInteract = false; //is the player close enough to talk to the NPC?
    public bool hasInteraction; //does the NPC have anything to say?

    public DialogueTrigger dt1; //the main dialogue
    public DialogueTrigger dt2; //the dialogue that gets repeated ad infinitum after the main dialogue
    DialogueTrigger dt; //the active dialogue trigger;

    public GameObject questCompleter;

    private void Start()
    {
        if (hasInteraction) { if (interactionMarker) { interactionMarker.SetActive(true); } }
        else { if (interactionMarker) { interactionMarker.SetActive(false); } }
        if (interactionPrompt) { interactionPrompt.SetActive(false); }

        dt = dt1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (hasInteraction)
            {
                if (interactionPrompt) { interactionPrompt.SetActive(true); Debug.Log("Setting InteractionPrompt to Active");
                    Debug.Log("HasInteraction: " + hasInteraction); }
                canInteract = true;
            }   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (/*hasInteraction*/ true)
            {
                if (interactionPrompt) { interactionPrompt.SetActive(false); }
                canInteract = false;
            }
        }
    }

    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                dt.TriggerDialogue();
                dt = dt2;

                hasInteraction = false;
                Debug.Log("HasInteraction from Update: " + hasInteraction);
                if (interactionMarker) { interactionMarker.SetActive(false); }
                if (interactionMarker) { interactionPrompt.SetActive(false); }

                if (questCompleter) { questCompleter.SetActive(true); }
            }
        }
    }
}
