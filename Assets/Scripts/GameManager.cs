using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    //private float timerTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //timerTime -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*timerTime = Time.deltaTime;
        if (timerTime <= 0)*/

    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }    
}
