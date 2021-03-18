using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    public float minTimeBetweenFlickers;
    public float maxTimeBetweenFlickers;
    public float minFlickerTime;
    public float maxFlickerTime;
    public float defaultIntensity;
    public float flickerIntensity;
    public Light light;

    private void Start()
    {
        light.intensity = defaultIntensity;

        StartCoroutine("FlickerCoroutine");
    }

    IEnumerator FlickerCoroutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minTimeBetweenFlickers, maxTimeBetweenFlickers);
            yield return new WaitForSeconds(waitTime);

            light.intensity = flickerIntensity;
            waitTime = Random.Range(minFlickerTime, maxFlickerTime);
            yield return new WaitForSeconds(waitTime);
            light.intensity = defaultIntensity;
        }
    }
}
