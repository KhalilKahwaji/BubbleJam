using UnityEngine;
using UnityEngine.SceneManagement;

public class GetBack : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
