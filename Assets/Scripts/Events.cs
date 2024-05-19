
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        PlayerManager.pause = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
