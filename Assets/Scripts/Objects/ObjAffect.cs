using UnityEngine;

public class ObjAffect : MonoBehaviour
{
    public int damages = 1;
    public int minusTimes;
    public int minusDistance;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            TimeCheck timeCheck = collision.gameObject.GetComponent<TimeCheck>();

            timeCheck.currentTime -= minusTimes;
            timeCheck.currentDistance -= minusDistance;
        }
    }
}
