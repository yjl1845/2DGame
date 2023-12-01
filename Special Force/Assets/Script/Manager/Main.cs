using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Option()
    {

    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
