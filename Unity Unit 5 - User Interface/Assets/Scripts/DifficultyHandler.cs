using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyHandler : MonoBehaviour
{
    private Button button;

    private GameManager gameManager;


    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(setDifficulty);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void setDifficulty(){
        Debug.Log(gameObject.name + " Was Clicked");
        gameManager.StartGame();
    }
}
