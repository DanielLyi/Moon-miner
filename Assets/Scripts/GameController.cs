using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerBalance playerBalance;
    [SerializeField] private TextMeshProUGUI _hashcoinTextMeshProUGUI;
    [SerializeField] private TextMeshProUGUI _moneyTextMeshProUGUI;
   

    // Update is called once per frame
    void Update()
    {
        _hashcoinTextMeshProUGUI.text = playerBalance.hashcoin.ToString("F6");
        _moneyTextMeshProUGUI.text = playerBalance.money.ToString("F");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
