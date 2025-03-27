using UnityEngine;

public class RotationMotion : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Vector3 velocity , spin;
    [SerializeField] PlayerController player ;
    bool isActive = false;

    void Start()
    {
        var go = GameObject.Find("Player");

        rb = GetComponent<Rigidbody>();
        player = go.GetComponent<PlayerController>();

        velocity = player.speed * velocity;
    }

    private void Update()
    {
        if (!isActive) 
        {
            ApplyMagnusEffect();
            isActive = true;
        }
    }

    void ApplyMagnusEffect()
    {
        spin.y = Random.Range(1, 4);

        rb.linearVelocity = velocity;
        rb.angularVelocity = spin;

        Vector3 magnusForce = Vector3.Cross(rb.linearVelocity, rb.angularVelocity);

        rb.AddForce(magnusForce);
    }
}
