using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;
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

        Instantiate
        (
            obstaclePrefab[randomObject], spawnPoint[randomPoint].position, obstaclePrefab[randomObject].transform.rotation
        );
    }

    IEnumerator SpawnCorontine()
    {
        yield return new WaitForSeconds(2f);

        while (!playerController.isGameOver)
        {
            for (int i = 0; i < 5; i++)
            {
                Spawn();
            }

            yield return new WaitForSeconds(2f);
        }

    }
}
