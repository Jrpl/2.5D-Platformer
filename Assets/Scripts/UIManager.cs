using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Coins
    [SerializeField]
    private Text _coinText;

    // Game Over
    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private Text _gameOverText;

    // Pause
    [SerializeField]
    private GameObject _pauseScreen;

    // Health
    [SerializeField]
    private GameObject _heart1;
    [SerializeField]
    private GameObject _heart2;
    [SerializeField]
    private GameObject _heart3;

    // Scripts
    private GameManager _gameManager;

    void Start()
    {
        _coinText.text = "Coins: " + 0;
        _heart1.SetActive(true);
        _heart2.SetActive(true);
        _heart3.SetActive(true);
        _gameOverScreen.gameObject.SetActive(false);
        _pauseScreen.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (!_gameManager)
        {
            Debug.LogError("Failed to find Game Object: Game_Manager");
        }
    }

    public void UpdateCoins(int coins)
    {
        _coinText.text = "Coins: " + coins;
    }

    public void UpdateHealthDisplay(int currentHealth)
    {
        switch (currentHealth)
        {
            case 2:
                _heart3.SetActive(false);
                break;
            case 1:
                _heart2.SetActive(false);
                break;
            case 0:
                _heart1.SetActive(false);
                GameOverSequence();
                break;
            default:
                Debug.LogError("Failed to update health display. Current Health: " + currentHealth);
                break;
        }
    }

    void GameOverSequence()
    {
        _gameManager.setGameOver();
        _gameOverScreen.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    public void SetPauseScreen(bool status)
    {
        _pauseScreen.SetActive(status);
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
