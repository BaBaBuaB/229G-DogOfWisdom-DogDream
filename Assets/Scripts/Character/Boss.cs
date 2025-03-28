using NUnit.Framework;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int healthBoss = 100;
    [SerializeField] TextMeshProUGUI bossHealth;

    private PlayerController playerController;

    private void Awake()
    {
        Debug.Log("Start");

        var player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        BossHealthUpdate();
    }

    private void Update()
    {
        if (!playerController.isGameOver)
        {
            if (healthBoss <= 0)
            {
                playerController.isGameWin = true;
            }
        }
    }

    public void BossHealthUpdate()
    {
        bossHealth.text = $"= {Convert.ToString(healthBoss)}";
    }
}
