using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameOver = false;
    private bool _isPaused = false;
    [SerializeField]
    private UIManager _uiManager;

    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (!_uiManager)
        {
            Debug.LogError("Failed to find Game Object: UIManager");
        }
    }

    void Update()
    {
        if (_gameOver)
        {
            if ((Input.GetKeyDown(KeyCode.R)))
            {
                SceneManager.LoadScene("Test Level");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                _isPaused = false;
                _uiManager.SetPauseScreen(_isPaused);
                Time.timeScale = 1;
            }
            else
            {
                _isPaused = true;
                _uiManager.SetPauseScreen(_isPaused);
                Time.timeScale = 0;
            }
        }
    }

    public void setGameOver()
    {
        _gameOver = true;
    }
}
