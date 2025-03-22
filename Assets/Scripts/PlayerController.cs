using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction luanchRoket;
    private int Health = 5;
    private float rayDistance = 200f;
    public GameObject vfxHitPoint;

    public int speed = 5;
    public int capasity = 3;

    public float xRange;
    public float yRange;

    public bool isGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");
        luanchRoket = InputSystem.actions.FindAction("Launch");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            MoveSideControl();
            MoveUpControl();
            Fire();
        }
    }

    void MoveSideControl()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.left);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    void MoveUpControl()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().y;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.up);

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if (transform.position.y > xRange)
        {
            transform.position = new Vector3(transform.position.x , yRange , transform.position.z);
        }
    }

    void Fire()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position,-transform.forward * rayDistance,Color.yellow);

        if (fireAction.IsPressed() && Physics.Raycast(transform.position,-transform.forward, out hit ,rayDistance))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Instantiate(vfxHitPoint, hit.point, Quaternion.identity);
            }
        }

        if (luanchRoket.IsPressed() && capasity > 0)
        {
            LaunchRoket();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Health -= 1;
            Destroy(collision.gameObject);

            if (Health <= 0)
            {
                isGameOver = true;
            }
        }
    }

    IEnumerator LaunchRoket()
    {
        yield return new WaitForSeconds(1);
    }
}
