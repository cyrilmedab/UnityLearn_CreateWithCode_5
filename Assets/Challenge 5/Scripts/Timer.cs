using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private GameManagerX gameManagerX;

    public int gameTime = 60;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = gameObject.GetComponent<GameManagerX>();
    }

    public void StartTimer()
    {
        StartCoroutine(TrackTime()); 
    }

    private void DisplayTime()
    {
        timerText.text = $"Time: {gameTime}";
    }

    IEnumerator TrackTime()
    {
        new WaitForSeconds(1f);

        while(gameManagerX.isGameActive)
        {
            gameTime -= 1;
            DisplayTime();
            if (gameTime == 0) gameManagerX.GameOver();
            yield return new WaitForSeconds(1f);
        }
    }
}
