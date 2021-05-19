using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Club");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
