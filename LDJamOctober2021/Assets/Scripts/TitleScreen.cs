using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Begin()
    {
        SceneManager.LoadScene(2);
    }
}
