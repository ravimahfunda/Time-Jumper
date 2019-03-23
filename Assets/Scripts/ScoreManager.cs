using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score;
    public PlayerBehaviours player;

    public Text scoreText;
    public Text highScoreText;

    private int highScore;

    private string HIGHSCORE_KEY = "HIGHSCORE";

    // Use this for initialization
    void Start () {
        score = 0;
        highScore = PlayerPrefs.GetInt(HIGHSCORE_KEY,0);
        highScoreText.text = highScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addScore(int amount) {
        score++;
        scoreText.text = score.ToString();
        Debug.Log("Score: " + score);
    }

    public void updateHighScore() {
        if (score > highScore) {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
            highScoreText.text = score.ToString();
        }
    }

    public void Retry() {
        if (player.isOver) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
