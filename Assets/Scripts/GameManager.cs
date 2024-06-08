using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;


public class GameManager : MonoBehaviour
{
    public Image gameOverScreen;

    public TextMeshProUGUI timerText;
    private float timerTime = 20f;
    private bool isGameOver = false;

    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {

        gameOverScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timerTime -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(timerTime).ToString();    
        }
        if (timerTime <= 0)
            GameOver();

        // Find all instances of MyScript in the scene
        StaminaManager[] allInstances = FindObjectsOfType<StaminaManager>();

        // Iterate through each instance and check the float value
        foreach (StaminaManager instance in allInstances)
        {
            float value = instance.Stamina;
            //Check stamina for game over condition
            if (value <= 0)
            {
                if (instance.name == "Skull P2")
                {
                    winText.text = "PLAYER 1 WINS!";
                }
                else
                {
                    winText.text = "PLAYER 2 WINS!";
                }

                GameOver();
            }
            Debug.Log("Found an instance with myFloat value: " + value);
        }
        
    }

    public void GameOver()
    {
        gameOverScreen.enabled = true;
        timerText.enabled = false;
        isGameOver = true;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }    
}
