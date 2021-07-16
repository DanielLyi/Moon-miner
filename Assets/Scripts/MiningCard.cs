using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningCard : MonoBehaviour
{
    [SerializeField] PlayerBalance playerBalance;
    [SerializeField] float amount;
    public int upgradeLvl;
    void Start()
    {
        InvokeRepeating("MineHashcoin", 2.0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        amount = upgradeLvl / 10f;
       
    }
    void MineHashcoin()
    {
        playerBalance.hashcoin += amount;
    }

}
