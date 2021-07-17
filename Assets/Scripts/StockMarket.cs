using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class StockMarket : MonoBehaviour
{
    private Random _random = new Random();
    
    private float _bestAskPrice = 2000.6f;
    private float _bestBidPrice = 2000.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdatePrice());
    }

    private IEnumerator UpdatePrice()
    {
        while (true)
        {
            _bestBidPrice = _bestBidPrice + 10 * GetNormalGaussRandom(); //random normal(mean,stdDev^2)
            _bestAskPrice = _bestBidPrice + 1 * Mathf.Abs(GetNormalGaussRandom());
            Debug.Log("bid " + _bestBidPrice.ToString());
            Debug.Log("ask " + _bestAskPrice.ToString());
            yield return new WaitForSeconds(0.2f);
        }
    }

    private float GetNormalGaussRandom()
    {
        double u1 = 1.0-_random.NextDouble(); //uniform(0,1] random doubles
        double u2 = 1.0-_random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                               Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        return (float) randStdNormal;
    }
}
