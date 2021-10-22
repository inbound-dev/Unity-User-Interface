using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Target : MonoBehaviour
{
    private Rigidbody PlayerRB;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;

    public Button restartButton;

    private float minSpeed = 12;
    private float maxSpeed = 16;

    private float range = 10;
    public float xRange = 14;

    public float ySpawnPos = 8.25f;

    public int pointVal;

    void Start(){
        PlayerRB = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        restartButton.gameObject.SetActive(false);

    }

    Vector3 RandomForce(){
       return Vector3.up * UnityEngine.Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque(){
        return UnityEngine.Random.Range(-range, range);
    }
    Vector3 RandomSpawnPos(){
        return new Vector3(UnityEngine.Random.Range(-xRange, xRange), ySpawnPos);
    }
    private void OnMouseDown(){
        if(gameManager.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            gameManager.UpdateScore(pointVal);
        }
    }
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad")){
            GameOver();
        }
    }
    public void GameOver(){
        gameManager.GameOverText.gameObject.SetActive(true);
        gameManager.isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
