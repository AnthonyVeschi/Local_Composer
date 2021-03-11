using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText; //the text which will hold the NPC's name
    public TextMeshProUGUI dialogueText; //the text which will hold the dialogue itself

    public GameObject canvas; //the canvas on which the ui elements are hosted

    public GameObject cam;
    MouseLook mouseLook;

    private Queue<string> sentences;

    Dialogue currentDialogue;

    private void Start()
    {
        sentences = new Queue<string>();

        canvas.SetActive(false);

        mouseLook = cam.GetComponent<MouseLook>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;

        mouseLook.UnlockMouse();

        canvas.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void EndDialogue()
    {
        canvas.SetActive(false);

        mouseLook.LockMouse();

        if (currentDialogue.quest)
        {
            QuestClass quest = currentDialogue.quest;
            if (!quest.activated) { quest.Activate(); }
            else { quest.Complete(); }
        }

        Debug.Log("end of conversation");
    }
}
