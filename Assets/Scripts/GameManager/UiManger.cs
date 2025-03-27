using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManger : MonoBehaviour
{
    void GototheStage()
    {
        SceneManager.LoadScene("FirstStage");
    }

    void GotoSetting()
    {

    }

    void ExitGame()
    {
        Application.Quit();
    }
}
