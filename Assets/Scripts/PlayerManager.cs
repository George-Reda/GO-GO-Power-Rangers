using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverPanel;
    public static bool IsGameStarted;
    public GameObject StartingText;
    public static int NumberOfRedCoins;
    public static int NumberOfGreenCoins;
    public static int NumberOfBlueCoins;
    public static int Total_Score;
    public Text CoinsText;
    public Text BlueCoins;
    public Text RedCoins;
    public Text GreenCoins;
    public GameObject PausePanel;
    public static bool pause;

    // Start is called before the first frame update
    void Start()
    {
        NumberOfRedCoins = 0;
        NumberOfGreenCoins = 0;
        NumberOfBlueCoins = 0;
        Total_Score = 0;
        gameOver = false;
        Time.timeScale = 1;
        IsGameStarted = false;
        pause = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            Total_Score = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
            PausePanel.SetActive(true);
            

        }
        
        if (!pause)
        {
            PausePanel.SetActive(false);
          
        }
//Total_Score = NumberOfRedCoins + NumberOfGreenCoins + NumberOfBlueCoins;
        CoinsText.text = "Total Score: " + Total_Score;
        if (NumberOfBlueCoins < 5)
        {
            BlueCoins.text = "Blue Coins: " + NumberOfBlueCoins;
        }
        else
        {
            BlueCoins.text = "Blue Coins: 5";
        }
        if (NumberOfGreenCoins < 5)
        {
            GreenCoins.text = "Green Coins: " + NumberOfGreenCoins;
        }
        else
        {
            GreenCoins.text = "Green Coins: 5";
        }
        if (NumberOfRedCoins < 5)
        {
            RedCoins.text = "Red Coins: " + NumberOfRedCoins;
        }
        else
        {
            RedCoins.text = "Red Coins: 5";
        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsGameStarted)
        {
            
            IsGameStarted = true;
            Destroy(StartingText);
        }
    }
}
