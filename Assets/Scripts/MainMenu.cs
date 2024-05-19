using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsPanel;
    public static bool panel=false;
    public static bool mute = false;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void options()
    {
        panel = true;
        OptionsPanel.SetActive(true);

    }
    public void MainMenu2()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void exit()
    {
        panel = false;
        OptionsPanel.SetActive(false);
    }
    public void mute2()
    {
        
    }
    public void unmute()
    {
        mute = false;
    }
}
