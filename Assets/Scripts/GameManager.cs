using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    private float spawnRate = 1f;

    private int score;
    private int lives = 3;
    public bool isGameOver;
    public bool isPaused = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isPaused) PauseGame();
        else if (Input.GetMouseButtonDown(1) && isPaused) ResumeGame();
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        isGameOver = false;

        score = 0;
        UpdateScore(0);
        UpdateLives(0);

        StartCoroutine(SpawnTarget());
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseScreen.SetActive(true);
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseScreen.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score:  {score}";
    }

    public void UpdateLives(int livesLost)
    {
        lives -= livesLost;
        livesText.text = $"Lives: {lives}";

        if (lives <= 0) GameOver();
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
