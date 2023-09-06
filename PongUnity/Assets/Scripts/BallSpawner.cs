using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;

    public Transform spawnPosition;
    public GameObject ballPrefab;

    GameObject currentBall;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnBall()
    {
        //Spawns ball based on prefab
        currentBall = Instantiate(ballPrefab, spawnPosition.position, transform.rotation, null);

        //Creates a new Vector direction that we will assign to the ball
        int randX = Random.Range(0, 2) * 2 - 1;
        float randY = Random.Range(-1.5f, 1.5f);
        Vector3 newDirection = new Vector3(randX, randY, 0);
        
        //Apply the new direction the ball
        currentBall.GetComponent<Ball>().direction = newDirection;
    }
}
