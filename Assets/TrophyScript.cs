using UnityEngine;

public class TrophyScript : MonoBehaviour
{
    public GameObject winUI;
    public static bool winning = false;

    
    void WinScenario()
    {

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.GetComponent<Animator>().Play("win");
        winning = true;
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
