using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedScene : MonoBehaviour
{
    public ScreenFader fading;

    public float sceneDuration;
    public int nextSceneIndex;

    private void FixedUpdate()
    {
        sceneDuration -= Time.fixedDeltaTime;

        if (sceneDuration <= 0)
        {
            sceneDuration = 999;
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        fading.FadeOut(Color.black);

        yield return new WaitUntil(() => fading.doneFadingOut);

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(nextSceneIndex);

        while (SceneManager.GetActiveScene().buildIndex != nextSceneIndex)
        {
            yield return null;
        }

        fading.FadeIn();
        Destroy(gameObject);
    }
}
