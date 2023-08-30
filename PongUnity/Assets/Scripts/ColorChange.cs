using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public SpriteRenderer engineBodyRenderer;
    public float speed;
    public Color startColor, endColor;
    float startTime;

    void Start()

    {

        startTime = Time.time;
        ChangeEngineColour();


        StartCoroutine(ChangeEngineColour());

    }

    private IEnumerator ChangeEngineColour()

    {
        float tick = 0f;
        while (engineBodyRenderer.material.color != endColor)
        {
            tick += Time.deltaTime * speed;

            engineBodyRenderer.material.color =
            Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));

            yield return null;
        }
    }
}
