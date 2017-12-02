using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public GameObject hazard2;
    public GameObject hazard3;
    public GameObject hazard4;

    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start ()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                int randomValue = (int)(Random.value * 10);
                if (randomValue % 2 == 0)
                {
                    Debug.Log(1);

                    Instantiate(hazard4, spawnPosition, hazard4.transform.rotation);

                } else if (randomValue % 3 == 0)
                {
                    Debug.Log(2);

                    Instantiate(hazard2, spawnPosition, spawnRotation);

                } else
                {
                    Debug.Log(3);

                    Instantiate(hazard3, spawnPosition, spawnRotation);

                }
                yield return new WaitForSeconds(spawnWait);

                if (!gameOver)
                {
                    restartText.text = "Pres 'R' for Restart";
                    restart = true;
                    break;
                }
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
