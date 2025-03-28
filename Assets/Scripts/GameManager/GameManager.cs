using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController con;
    public static GameManager instance;
    public bool isGamePaused = false;
    public GameObject lossScreen;
    public GameObject winScreen;
    public GameObject settingScreen;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (con.isGameWin)
        {
            PauseGame();
            winScreen.SetActive(true);
        }

        if (con.isGameOver)
        {
            PauseGame();
            lossScreen.SetActive(true);
        }

        if (con.setting.triggered)
        {
            PauseGame();
            settingScreen.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        isGamePaused = true;
        con.isGamePause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        isGamePaused = false;
        con.isGamePause = false;
        settingScreen.SetActive(false);
    }
}
