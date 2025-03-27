using UnityEngine;

public class GainSpeed : Gain
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gain = 1;

        var search = GameObject.Find("Player");

        playerCon = search.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCon.speed += gain;
            playerCon.SpeedDisplay();

            if (playerCon.health < 5)
            {
                playerCon.health += gain;
                playerCon.HealthDisplay();
            }

            Destroy(this.gameObject);
        }
    }

}
