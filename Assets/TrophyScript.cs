using UnityEngine;

public class TrophyScript : MonoBehaviour
{
    public GameObject winUI;


    void WinScenario()
    {
        PauseController.GlobalPauseGame();
        winUI.SetActive(true);
        AudioManagerScript.INSTANCE.PlayTrack(AudioManagerScript.Audio_Ids.WIN_TRACK);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            WinScenario();
        }
    }
}
