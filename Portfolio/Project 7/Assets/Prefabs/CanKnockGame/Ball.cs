using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    Transform ballSpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        spawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBall()
    {
        GameObject.Instantiate<GameObject>(ballPrefab, ballSpawnLocation.position, Quaternion.identity);
    }
}
