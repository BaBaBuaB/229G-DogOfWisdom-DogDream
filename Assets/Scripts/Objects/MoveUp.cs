using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveUp : MonoBehaviour
{
    Vector3 top = Vector3.up;
    int speed = 10;

    float timeCount = 0;

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
