using UnityEngine;
using TMPro;
using System;

public class TimeCheck : MonoBehaviour
{
    public float currentTime = 100;
    private float winDistance = 50000;

    [SerializeField] TextMeshProUGUI[] distanceTxt;

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
        
        
            if (!controller.isGameOver)
            {
                if (currentTime <= 0)
                {
                    controller.isGameOver = true;
                }

                currentTime -= Time.deltaTime;
                TimeUpdate();

                currentDistance += controller.speed;
                DistanceUpdate();

                if (currentDistance >= winDistance)
                {
                    controller.isGameWin = true;
                }
            }
        
    }

    void TimeUpdate()
    {
        distanceTxt[0].text = $"Time = {Convert.ToString(currentTime)}" ;
    }

    void DistanceUpdate()
    {
        distanceTxt[1].text = $"Distance = {Convert.ToString(currentDistance)}/{Convert.ToString(winDistance)}";
    }
}
