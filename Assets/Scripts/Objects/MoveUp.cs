using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveUp : MonoBehaviour
{
    Vector3 top = Vector3.up;
    int speed;

    float timeCount;


    private void Awake()
    {
        Time.timeScale = 1;

        Debug.Log("Start");

        speed = 10;
        timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(top * speed * Time.deltaTime);

        timeCount += Time.deltaTime;

        if (timeCount >= 25)
        {
            SceneManager.LoadScene(0);
        }
    }
}
