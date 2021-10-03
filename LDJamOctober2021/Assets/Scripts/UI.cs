using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] float gameOverScreenDelay;
    [SerializeField] Text ScoreLabel;
    bool isPaused = false;

    public void ShowGameOverScreen()
    {
        StartCoroutine(ShowGameOverAfterDelay());
    }

    IEnumerator ShowGameOverAfterDelay()
    {
        yield return new WaitForSeconds(gameOverScreenDelay);
        ScoreLabel.text = $"Deliveries Made: {GameManager.score}";
        GameOverScreen.SetActive(true);
        
    }
    public void OnRetryClick()
    {
        SceneManager.LoadScene(2);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1f;
            } else
            {
                Time.timeScale = 0f;
            }
            isPaused = !isPaused;
            
        }
    }
}
