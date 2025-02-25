using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThroughScenes : MonoBehaviour
{
    private const int _menuBuildIndex = 0;
    private const int _gameBuildIndex = 1;

    public void GoToNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == _menuBuildIndex)
        {
            SceneManager.LoadScene(_gameBuildIndex);
        }
        else if (SceneManager.GetActiveScene().buildIndex == _gameBuildIndex)
        {
            SceneManager.LoadScene(_menuBuildIndex);
        }
    }
}
