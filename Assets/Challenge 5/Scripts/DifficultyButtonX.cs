using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button button;
    private GameObject gameManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        button.onClick.AddListener(gameManager.GetComponent<Timer>().StartTimer);
    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the button 
    */
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManager.GetComponent<GameManagerX>().StartGame(difficulty);
    }



}
