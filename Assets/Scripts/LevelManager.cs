using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public string sceneName;
    public float fadeDuration = 1f;

    void Start()
    {
        StartCoroutine(FadeOut(1f, 0f));
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeInAndLoadScene(sceneName));
    }

    IEnumerator FadeOut(float startAlpha, float endAlpha)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
    }

    IEnumerator FadeInAndLoadScene(string sceneName)
    {
        yield return StartCoroutine(FadeOut(0f, 1f));
        SceneManager.LoadScene(sceneName);
    }
}
