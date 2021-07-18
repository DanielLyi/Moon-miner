using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MiningCard : MonoBehaviour
{
    
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
        _amount = upgradeLvl / 1000f;
        _moneyForUpgrade = upgradeLvl * 1000f + 150f;
    }

    void MineHashcoin()
    {
        playerBalance.hashcoin += _amount;
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