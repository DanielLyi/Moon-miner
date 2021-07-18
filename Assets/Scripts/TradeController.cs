using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TradeController : MonoBehaviour
{
    [SerializeField] private StockMarket stockMarket;
    [SerializeField] private PlayerBalance playerBalance;
    [SerializeField] private TMP_InputField usdAmountInput;
    [SerializeField] private TMP_InputField hashcoinAmountInput;
    [SerializeField] private Toggle shortToggle;

    public void Buy()
    {
        float moneyToSpend = float.Parse(usdAmountInput.text);
        float hashcoinAmount = moneyToSpend / stockMarket.GetBestAskPrice();
        if (playerBalance.money >= moneyToSpend)
        {
            playerBalance.money -= moneyToSpend;
            playerBalance.hashcoin += hashcoinAmount;
        }
    }

    public void Sell()
    {
        float hashcoinAmount = float.Parse(hashcoinAmountInput.text);
        float moneyToGet = hashcoinAmount * stockMarket.GetBestBidPrice();
        if (playerBalance.hashcoin >= hashcoinAmount)
        {
            playerBalance.hashcoin -= hashcoinAmount;
            playerBalance.money += moneyToGet;
        }
    }
}
