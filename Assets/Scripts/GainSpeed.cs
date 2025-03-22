using UnityEngine;

public class GainSpeed : Gain
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gain = 5;

        var search = GameObject.Find("Player");

        playerCon = search.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCon.speed += gain;
            Destroy(this.gameObject);
        }
    }

}
