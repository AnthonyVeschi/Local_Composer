using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleDropScript : MonoBehaviour
{
    public GameObject textObj;
    public GameObject imageObj;
    
    public GameObject player;
    public GameObject cam;

    Text text;
    Image image;

    PlayerMovement moveScript;
    MouseLook lookScript;

    public float textStartFadeInTime;
    public float textEndFadeInTime;
    public float textStartFadeOutTime;
    public float textEndFadeOutTime;

    public float imageStartFadeWhiteTime;
    public float imageEndFadeWhiteTime;
    public float imageStartFadeClearTime;
    public float imageEndFadeClearTime;

    public float canMoveTime;

    private void Start()
    {
        text = textObj.GetComponent<Text>();
        image = imageObj.GetComponent<Image>();

        moveScript = player.GetComponent<PlayerMovement>();
        lookScript = cam.GetComponent<MouseLook>();
        moveScript.enabled = false;
        lookScript.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;

        StartCoroutine("TheCoroutine");
    }

    IEnumerator TheCoroutine()
    {
        while (Time.time < textStartFadeInTime) { yield return null; }

        float fadeTime = textEndFadeInTime - textStartFadeInTime;
        float startTime = Time.time;
        byte alpha;
        float t;
        while (Time.time < textEndFadeInTime)
        {
            t = (Time.time - startTime) / fadeTime;
            alpha = (byte)Mathf.Lerp(0, 255, t);
            text.color = new Color32(255, 255, 255, alpha);
            yield return null;
        }
        text.color = new Color32(255, 255, 255, 255);

        while (Time.time < textStartFadeOutTime) { yield return null; }

        fadeTime = textEndFadeOutTime - textStartFadeOutTime;
        startTime = Time.time;
        while (Time.time < textEndFadeOutTime)
        {
            t = (Time.time - startTime) / fadeTime;
            alpha = (byte)Mathf.Lerp(255, 0, t);
            text.color = new Color32(255, 255, 255, alpha);
            yield return null;
        }
        text.color = new Color32(255, 255, 255, 0);

        while (Time.time < imageStartFadeWhiteTime) { yield return null; }

        fadeTime = imageEndFadeWhiteTime - imageStartFadeWhiteTime;
        startTime = Time.time;
        while (Time.time < imageEndFadeWhiteTime)
        {
            t = (Time.time - startTime) / fadeTime;
            alpha = (byte)Mathf.Lerp(0, 255, t);
            image.color = new Color32(alpha, alpha, alpha, 255);
            yield return null;
        }
        image.color = new Color32(255, 255, 255, 255);

        while (Time.time < imageStartFadeClearTime) { yield return null; }

        fadeTime = imageEndFadeClearTime - imageStartFadeClearTime;
        startTime = Time.time;
        while (Time.time < imageEndFadeClearTime)
        {
            t = (Time.time - startTime) / fadeTime;
            alpha = (byte)Mathf.Lerp(255, 0, t);
            image.color = new Color32(255, 255, 255, alpha);
            yield return null;
        }
        image.color = new Color32(255, 255, 255, 0);

        while (Time.time < canMoveTime) { yield return null; }

        moveScript.enabled = true;
        lookScript.enabled = true;

        Destroy(gameObject);
    }
}
