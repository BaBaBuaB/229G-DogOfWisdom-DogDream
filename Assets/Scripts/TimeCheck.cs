using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    public float currentTime = 100;

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
        }
    }
}
