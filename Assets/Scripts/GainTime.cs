using UnityEngine;

public class GainTime : Gain
{
    private void Awake()
    {
        gain = 10;

        var search = GameObject.Find("Player");

        timeCheck = search.GetComponent<TimeCheck>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timeCheck.currentTime += gain;
            Destroy(this.gameObject);
        }
    }
}
