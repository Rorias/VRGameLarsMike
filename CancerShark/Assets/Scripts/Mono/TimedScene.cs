using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedScene : MonoBehaviour
{
    public float sceneDuration;
    public int nextSceneIndex;

    private void FixedUpdate()
    {
        sceneDuration -= Time.fixedDeltaTime;

        if (sceneDuration <= 0)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
