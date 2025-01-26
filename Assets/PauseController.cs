using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    public static bool gameIsPaused = false;

    [SerializeField]
    public GameObject pauseMenu;// victoryMenu, defeatMenu;
    [SerializeField]
    public Button pauseButton;


    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
        pauseButton.enabled = false;
    }

    public static void GlobalPauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenu.gameObject.SetActive(false);
        pauseButton.enabled = true;

    }

    public void RestartGame()
    {
        PlayerHealth.dead = false;
        Time.timeScale = 1f;
        AudioManagerScript.INSTANCE.PlayTrack(AudioManagerScript.Audio_Ids.MAIN_TRACK);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        PlayerHealth.dead = false;
        AudioManagerScript.INSTANCE.PlayTrack(AudioManagerScript.Audio_Ids.MAIN_MENU_TRACK);
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(int level)
    {
        PlayerHealth.dead = false;
        Time.timeScale = 1f;

        if (level != 4)
            AudioManagerScript.INSTANCE.PlayTrack(AudioManagerScript.Audio_Ids.MAIN_TRACK);
        else
            AudioManagerScript.INSTANCE.StopTrack();

       SceneManager.LoadScene("Level" + level);
    }

    public void NextLevel()
    {
        PlayerHealth.dead = false;
        AudioManagerScript.INSTANCE.PlayTrack(AudioManagerScript.Audio_Ids.MAIN_TRACK);
        string curScene = SceneManager.GetActiveScene().name;
        int nextInd = SceneManager.GetActiveScene().buildIndex + 1;

    }

    public void ExitGame()
    { 
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}//class
