using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToNextScene());
    }

    IEnumerator MoveToNextScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }
}
