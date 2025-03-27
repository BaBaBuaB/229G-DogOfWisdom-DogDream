using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;
    public int spawnCounts;
    List<Transform> usedSpawn = new List<Transform>();

    public GameObject[] obstaclePrefab;
    private PlayerController playerController;

    private void Awake()
    {
        var player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*if (!playerController.isGameOver)
        {
            InvokeRepeating(nameof(Spawn), 1, 3);
        }*/

        StartCoroutine(SpawnCorontine());
    }

    void Spawn()
    {
        int randomPoint = Random.Range(0, spawnPoint.Length);

        int randomObject = Random.Range(0, obstaclePrefab.Length);


        if (!usedSpawn.Contains(transform))
        {
            Instantiate
            (
                obstaclePrefab[randomObject], spawnPoint[randomPoint].position, obstaclePrefab[randomObject].transform.rotation
            );

            usedSpawn.Add(spawnPoint[randomPoint]);

            spawnCounts++;
        }

    }

    IEnumerator SpawnCorontine()
    {
        yield return new WaitForSeconds(2f);

        while (!playerController.isGameOver)
        {
            do
            {
                Spawn();
            }
            while (spawnCounts < 5);

            usedSpawn.Clear();

            spawnCounts = 0;

            yield return new WaitForSeconds(2f);
        }

    }
}
