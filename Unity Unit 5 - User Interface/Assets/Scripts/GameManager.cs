using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public float SpawnRate = 1.0f;
    private int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;

    public bool isGameActive = true;

    void Start()
    {
        StartCoroutine(SpawnTargets());

        UpdateScore(0);
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
}
