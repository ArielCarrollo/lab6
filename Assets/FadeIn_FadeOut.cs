using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeIn_FadeOut : MonoBehaviour
{
    public Image fadeImage; 
    public string sceneToLoad; 
    public float fadeDuration = 1f; 

    private void Start()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FadeAndChangeScene());
        }
    }

    private IEnumerator FadeAndChangeScene()
    {
        yield return StartCoroutine(Fade(1));
        SceneManager.LoadScene(sceneToLoad);
        yield return StartCoroutine(Fade(0));
    }

    private IEnumerator Fade(int targetAlpha)
    {
        float alpha = targetAlpha == 1 ? 0 : 1;
        float time = 0;

        while (time < fadeDuration)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Lerp(alpha, targetAlpha, time / fadeDuration));
            time += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, targetAlpha);
    }
}
