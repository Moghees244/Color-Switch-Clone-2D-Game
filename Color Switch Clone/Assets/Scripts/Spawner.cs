using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    public Transform[] obstacles;
    public Transform colorChanger;
    public Transform player;
    UnityEngine.Vector3 spawnPosition;
    int index;
    int obstaclesPassed = 0;
    int obstacleDestroyDifference = 3;
    public float lastObstacleHeight = 0f;
    Queue<Transform> obstaclesInGame;
    Queue<Transform> colorChnagersInGame;

    private void Start()
    {
        index = UnityEngine.Random.Range(0, obstacles.Length);
        spawnPosition = player.position;
        obstaclesInGame = new Queue<Transform>();
        colorChnagersInGame = new Queue<Transform>();
        spawnObstacle();
    }

    private void Update()
    {
        if (obstaclesInGame.Count < 5)
            spawnObstacle();

        if (
            obstaclesPassed + obstacleDestroyDifference
            == player.GetComponent<Player>().obstaclesCrossed
        )
        {
            Transform temp = obstaclesInGame.Dequeue();
            lastObstacleHeight = temp.position.y;
            Destroy(temp.gameObject);
            obstaclesPassed = player.GetComponent<Player>().obstaclesCrossed;
            obstacleDestroyDifference = 1;
        }
    }

    void spawnObstacle()
    {
        Transform newObstacle;
        Transform newColorChanger;

        spawnPosition.y += 10;
        newObstacle =
            Instantiate(obstacles[index], spawnPosition, quaternion.identity) as Transform;
        spawnPosition.y += 5;
        newColorChanger =
            Instantiate(colorChanger, spawnPosition, quaternion.identity) as Transform;

        obstaclesInGame.Enqueue(newObstacle);
        colorChnagersInGame.Enqueue(newColorChanger);
    }

    public void onDeath()
    {
        for (int i = 0; i < obstaclesInGame.Count; i++)
        {
            Transform temp = obstaclesInGame.Dequeue();
            Destroy(temp.gameObject);
        }

        for (int i = 0; i < colorChnagersInGame.Count; i++)
        {
            Transform temp = colorChnagersInGame.Dequeue();

            if (temp != null)
                Destroy(temp.gameObject);
        }
    }
}
