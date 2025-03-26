using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float speedObj;

    private int leftBound = -20;
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var go = GameObject.Find("Player");

        playerController = go.GetComponent<PlayerController>();
        speedObj = playerController.speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speedObj);
        }

        if (transform.position.z < leftBound && gameObject)
        {
            Destroy(gameObject);
        }
    }
}
