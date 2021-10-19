using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody PlayerRB;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float range = 10;
    public float xRange = 4;
    public float ySpawnPos = -6;

    void Start(){
        PlayerRB = GetComponent<Rigidbody>();

    }

    void RandomForce(){
        PlayerRB.AddForce(Vector3.up * UnityEngine.Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
    }
    void RandomTorque(){
        PlayerRB.AddTorque(UnityEngine.Random.Range(-range, range), UnityEngine.Random.Range(-range, range), UnityEngine.Random.Range(-range, range), ForceMode.Impulse);
    }
    void RandomSpawnPos(){
        transform.position = new Vector3(UnityEngine.Random.Range(-xRange, xRange), ySpawnPos);
    }
}
