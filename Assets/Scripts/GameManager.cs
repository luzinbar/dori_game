using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score;

    public void Awake() {
        Application.targetFrameRate = 60; // the game will run in 60 frames a seconds
        Pause(); // whait for tha player to hit the play button
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        
        Time.timeScale = 1f;
        player.enabled = true;
        
        Animals[] animals = FindObjectsOfType<Animals>();
        
        for (int i=0; i<animals.Length; i++){
            Destroy(animals[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver() {
        // Debug.Log("Game over");
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public int Get_score(){
        return score;
    }
}
