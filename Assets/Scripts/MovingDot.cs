using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDot : MonoBehaviour
{
    private bool _move;
    [SerializeField] private StockMarket _stockMarket;
    [SerializeField] private float _yToMove;
    private float _minPriceWhenInstantiated;

    private void Start()
    {
        _minPriceWhenInstantiated = _stockMarket.GetBotPriceValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            transform.Translate(-20 * Time.deltaTime, 0, 0);
        }

        float change;
        if (Mathf.Abs((change = _minPriceWhenInstantiated - _stockMarket.GetBotPriceValue())) > Mathf.Epsilon)
        {
            transform.Translate(0, (change / 100) * _yToMove, 0);
            _minPriceWhenInstantiated = _stockMarket.GetBotPriceValue();
        }
    }

    public void SetMove(bool move)
    {
        _move = move;
    }
}