using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] PlayerBalance playerBalance;
    [SerializeField] MiningCard miningCard;
    float _moneyForUpgrade;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        UpgradeMiningCard();
    }
    void UpgradeMiningCard()
    {
        if (_moneyForUpgrade >= playerBalance.money)
        {
            miningCard.upgradeLvl += 1;
        }
    }
}
