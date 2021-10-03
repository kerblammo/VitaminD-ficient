using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    [Header("Game Over Screen")]
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] float gameOverScreenDelay;
    [SerializeField] Text ScoreLabel;

    [Header("Pause Menu")]
    [SerializeField] GameObject PauseScreen;
    [SerializeField] Toggle BGMToggle;
    [SerializeField] AudioMixer BGMMixer;
    [SerializeField] Toggle SFXToggle;
    [SerializeField] AudioMixer SFXMixer;

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

    public void ToggleBGM()
    {
        float volume = BGMToggle.isOn ? 0f : -80f;
        BGMMixer.SetFloat("Volume", volume);
    }

    public void ToggleSFX()
    {
        float volume = SFXToggle.isOn ? 0f : -80f;
        SFXMixer.SetFloat("Volume", volume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                PauseScreen.SetActive(false);
                Time.timeScale = 1f;
            } else
            {
                PauseScreen.SetActive(true);
                Time.timeScale = 0f;
            }
            isPaused = !isPaused;
            
        }
    }
}
