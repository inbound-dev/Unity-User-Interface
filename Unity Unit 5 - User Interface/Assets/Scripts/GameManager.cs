using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public float SpawnRate = 1.0f;
    private int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI TitleText;

    public Button restartButton;

    public bool isGameActive = true;

    void Start()
    {
        StartCoroutine(SpawnTargets());

        UpdateScore(0);

        TitleText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    void Update(){
        if(!isGameActive == true){
            restartButton.gameObject.SetActive(true);
            GameOverText.gameObject.SetActive(true);
        }
        else{
            restartButton.gameObject.SetActive(false);
            GameOverText.gameObject.SetActive(false);
            TitleText.gameObject.SetActive(false);
        }
    }

    IEnumerator SpawnTargets(){
        while (isGameActive)
        {
             yield return new WaitForSeconds(SpawnRate);
             int index = UnityEngine.Random.Range(0, targets.Count-1);

             Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int ScoreToAdd){
        score += ScoreToAdd;
        scoreText.text = "Score: " + score;

    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
