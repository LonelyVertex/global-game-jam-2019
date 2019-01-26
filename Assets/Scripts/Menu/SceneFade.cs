using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    float duration;

    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));
    }

    IEnumerator Fade(float from, float to)
    {
        Color color = image.color;

        var currentDuration = 0f;
        while (currentDuration <= duration) {
            currentDuration += Time.deltaTime;

            color.a = Mathf.Lerp(from, to, currentDuration / duration);
            image.color = color;

            yield return null;
        }
    }
}
