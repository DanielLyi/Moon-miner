﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class StockMarket : MonoBehaviour
{
    private Random _random = new Random();
    
    private double _price = 2000.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdatePrice());
    }

    private IEnumerator UpdatePrice()
    {
        while (true)
        {
            double u1 = 1.0-_random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0-_random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                   Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            _price = _price + 10 * randStdNormal; //random normal(mean,stdDev^2)
            Debug.Log(_price.ToString());
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
