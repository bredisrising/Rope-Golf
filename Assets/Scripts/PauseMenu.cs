using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] PlayerCon playerCon;

    [SerializeField] AudioClip select;
    [SerializeField] AudioSource src;

    [SerializeField] Manager manager;

    
    public void Pause()
    {
        src.PlayOneShot(select);
        playerCon.line.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void Resume()
    {
        src.PlayOneShot(select);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        manager.SaveStars();
        PlayerPrefs.SetInt("stars", manager.numStars);
        PlayerPrefs.SetInt("lvl", manager.currentLvlIndex);
        src.PlayOneShot(select);
        SceneManager.LoadScene("Start");
    }

    public void Quit()
    {
        manager.SaveStars();
        PlayerPrefs.SetInt("stars", manager.numStars);
        PlayerPrefs.SetInt("lvl", manager.currentLvlIndex);
        src.PlayOneShot(select);
        Application.Quit();
    }

}
