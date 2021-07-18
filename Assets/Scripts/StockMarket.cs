using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class StockMarket : MonoBehaviour
{
    [SerializeField] private GameObject bidDot;
    [SerializeField] private GameObject askDot;
    [SerializeField] GameObject topPrice;
    [SerializeField] GameObject midPrice;
    [SerializeField] GameObject botPrice;
    [SerializeField] bool isLonging;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] private GameObject bidDotsParent;
    [SerializeField] private GameObject askDotsParent;
    private float _topPriceValue = 2100;
    private float _botPriceValue = 1900;

    private Random _random = new Random();

    private float _bestAskPrice = 2000.6f;
    private float _bestBidPrice = 2000.5f;

    [SerializeField] private float _x;

    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        _coroutine = StartCoroutine(UpdatePrice());
    }

    private IEnumerator UpdatePrice()
    {
        while (true)
        {
            _bestBidPrice = _bestBidPrice + 2 * GetNormalGaussRandom(); //random normal(mean,stdDev^2)
            _bestAskPrice = _bestBidPrice + 10;
            if (_bestAskPrice > _topPriceValue)
            {
                _botPriceValue += 100f;
                _topPriceValue += 100f;
                botPrice.GetComponent<TextMeshProUGUI>().text = _botPriceValue.ToString();
                midPrice.GetComponent<TextMeshProUGUI>().text = ((_topPriceValue + _botPriceValue) / 2).ToString();
                topPrice.GetComponent<TextMeshProUGUI>().text = _topPriceValue.ToString();
            }

            if (_bestBidPrice < _botPriceValue)
            {
                _botPriceValue -= 100f;
                _topPriceValue -= 100f;
                botPrice.GetComponent<TextMeshProUGUI>().text = _botPriceValue.ToString();
                midPrice.GetComponent<TextMeshProUGUI>().text = ((_topPriceValue + _botPriceValue) / 2).ToString();
                topPrice.GetComponent<TextMeshProUGUI>().text = _topPriceValue.ToString();
            }
            UpdateChart();
            
            if (isLonging)
            {
                priceText.text = "Price: " + _bestAskPrice.ToString("F");
            }
            else
            {
                priceText.text = "Price: " + _bestBidPrice.ToString("F");
            }
            
            
            yield return new WaitForSeconds(0.1f);
        }
    }


    private float GetNormalGaussRandom()
    {
        double u1 = 1.0 - _random.NextDouble(); //uniform(0,1] random doubles
        double u2 = 1.0 - _random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                               Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        return (float) randStdNormal;
    }

    private void UpdateChart()
    {
        var position = botPrice.transform.position;
        var position1 = topPrice.transform.position;
        bidDot.gameObject.transform.position = new Vector2(bidDot.gameObject.transform.position.x,
            position.y +
            (position1.y - position.y) *
            ((_bestBidPrice - _botPriceValue) / (_topPriceValue - _botPriceValue)));
        askDot.gameObject.transform.position = new Vector2(askDot.gameObject.transform.position.x,
            position.y +
            (position1.y - position.y) *
            ((_bestAskPrice - _botPriceValue) / (_topPriceValue - _botPriceValue)));
        bidDot.GetComponent<MovingDot>().SetMove(true);
        askDot.GetComponent<MovingDot>().SetMove(true);
        bidDot = Instantiate(bidDot, new Vector3(_x, bidDot.transform.position.y, 0),
            Quaternion.identity, bidDotsParent.transform);
        askDot = Instantiate(askDot, new Vector3(_x, askDot.transform.position.y, 0),
            Quaternion.identity, askDotsParent.transform);
    }

    public float GetBotPriceValue()
    {
        return _botPriceValue;
    }

    public float GetBestAskPrice()
    {
        return _bestAskPrice;
    }
    public float GetBestBidPrice()
    {
        return _bestBidPrice;
    }
    
}