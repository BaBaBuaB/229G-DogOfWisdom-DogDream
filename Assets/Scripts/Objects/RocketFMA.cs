using Unity.VisualScripting;
using UnityEngine;

public class RocketFMA : MonoBehaviour
{
    [SerializeField]private PlayerController player;
    public float mass;
    public float force;
    public float speedRocket;

    private int outOfBound = 30;

    bool use = false;

    private void Awake()
    {
        var go = GameObject.Find("Player");

        player = go.GetComponent<PlayerController>();
        mass = GetComponent<Rigidbody>().mass;

        speedRocket = player.speed * 2;
    }

    private void Update()
    {
        if (!use)
        {
            ForceCalculate();

            use = true;
        }

        if (transform.position.z > outOfBound && gameObject)
        {
            Destroy(gameObject);
        }
    }

    void ForceCalculate()
    {
        force = mass * speedRocket/Time.deltaTime;

        GetComponent<Rigidbody>().AddForce(0, 0, force);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Boss")) 
        {
            Destroy(collision.gameObject);

            ForceCalculate();
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();

            boss.healthBoss -= player.dmg * 10;
        }
    }
}
