using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    // Start is called before the first frame update
    void Start()
    {
        _coinText.text = "Coins: " + 0;
    }

    // Update is called once per frame
    public void UpdateCoins(int coins)
    {
        _coinText.text = "Coins: " + coins;
    }
}
