using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiningCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] PlayerBalance playerBalance;
    float _amount;
    public int upgradeLvl;
    float _moneyForUpgrade;
    void Start()
    {
        InvokeRepeating("MineHashcoin", 2.0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        _amount = upgradeLvl / 10f;
        _moneyForUpgrade = upgradeLvl * 100f + 150f;
    }

    void MineHashcoin()
    {
        playerBalance.hashcoin += _amount;
        _textMeshProUGUI.text = playerBalance.hashcoin.ToString();
    }
    public void UpgradeMiningCard()
    {
        
        if (_moneyForUpgrade <= playerBalance.money)
        {
            
            upgradeLvl += 1;
            playerBalance.money = playerBalance.money - _moneyForUpgrade;
        }
    }

}