using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void StartCutscene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

    public void StartCutscene(string _name)
    {
        SceneManager.LoadScene(_name);
    }
}
