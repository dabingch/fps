using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Text _timerText;

    private int _remainingTime = 30;

    private GameManager _gameManager;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _timerText.text = "Time: " + _remainingTime;
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager is null)
        {
            Debug.LogError("Game Manager is null");
        }

        StartCoroutine(TimerRountine());
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    IEnumerator TimerRountine()
    {
        while (_remainingTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            _remainingTime--;
            _timerText.text = "Time: " + _remainingTime;
            
            if (_remainingTime <= 0)
            {
                GameOverSequence();
            }
        }
    }

    private void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(.5f);
        }
    }
}
