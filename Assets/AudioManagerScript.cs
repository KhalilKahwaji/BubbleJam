//using UnityEditor.SearchService;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;
    public static AudioManagerScript INSTANCE;

    private void Awake()
    {
        if (INSTANCE != null && INSTANCE != this)
        {
            Destroy(gameObject);
        }
        else
        {
            INSTANCE = this;

            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public enum Audio_Ids
    {
        MAIN_TRACK = 0,
        WIN_TRACK = 1,
        LOSE_TRACK = 2,
        MAIN_MENU_TRACK = 3

    }

    public void PlayTrack(Audio_Ids id)
    {
        audioSource.Stop();
        audioSource.clip = clips[(int)id];
        audioSource.Play();
    }
    public void StopTrack()
    {
        audioSource.Stop();
    }

}
