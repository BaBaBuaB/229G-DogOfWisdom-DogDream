using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int healthBoss = 100;
    public int[] reachDistance;

    private PlayerController playerController;

    private void Awake()
    {
        var player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!playerController.isGameOver)
        {
            Move();

            if (healthBoss <= 0)
            {
                playerController.isGameWin = true;
            }
        }
    }

    void Move()
    {
        if (transform.position.y < reachDistance[0])
        {
            
        }
    }
}
