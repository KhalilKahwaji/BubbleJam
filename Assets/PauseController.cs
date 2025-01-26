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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void LoadMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

    public void NextLevel()
    {
        string curScene = SceneManager.GetActiveScene().name;
        int nextInd = SceneManager.GetActiveScene().buildIndex + 1;
        /*if (curScene == TagsEnum.Instance.ns_scene_level04)
        {
            SceneManager.LoadScene(TagsEnum.Instance.ns_scene_level00);
        }
        else
        {
            SceneManager.LoadScene(nextInd);
        }*/
    }

    public void ExitGame()
    { 
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}//class
