using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFunction : MonoBehaviour
{
    public int sentenceNum; //the number of the sentence after which this function fires
    public int currentSentence = 0; //the sentence that we are currently on

    public void IncrementSentence()
    //decide in dialogue manager whether to call this before or after displaying the sentence
    {
        currentSentence++;
        if (currentSentence == sentenceNum)
        {
            MyFunction();
        }
    }

    public virtual void MyFunction() { }
}
