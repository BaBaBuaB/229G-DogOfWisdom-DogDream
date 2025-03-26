using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    public float currentTime = 100;
    public float winDistance = 2000;

    public float currentDistance = 0;

    public PlayerController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (currentTime <= 0)
        {
            controller.isGameOver = true;
        }

        if (!controller.isGameOver)
        {
            currentTime -= Time.deltaTime;

            currentDistance += controller.speed;

            if (currentDistance >= winDistance)
            {
                controller.isGameWin = true;
            }
        }
    }
}
