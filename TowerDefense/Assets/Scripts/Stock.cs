using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class Stock 
{
    private float _startingStockPrice;
    private float _stockVolatility;
    private float _currentStockPrice;
    private string _stockName;
    private int _GafStockAmount;
    private int _GnomeStockAmount;
    private int _NahWeUpStockAmount;

    public Stock(float startingStockPrice, float volatility, string Name)
    {
        _startingStockPrice= startingStockPrice;
        _stockVolatility= volatility;
        _stockName= Name;
        _currentStockPrice = startingStockPrice;
    }

    public void changeStockPrice()
    {
        
        float _stockVariation = randomNumber(-0.2f, 0.2f);
        float _stockPercentageIncrease = _stockVariation * StockVolatility;
        StockCurrentPrice = StockCurrentPrice + (StockCurrentPrice * _stockPercentageIncrease);

        if (StockCurrentPrice < 5.0f)
        {
            StockCurrentPrice = 5.0f;
        }else if(StockCurrentPrice > 100f) {
            StockCurrentPrice = 100f;
        }
    }

    public float randomNumber(float _number1, float _number2)
    {
        float _randomNumber = Random.Range(_number1, _number2);
        return _randomNumber;
    }

   

    public string StockName {
        get { return _stockName; }
        set
        {
            _stockName = value;
        }

    }
    public float StockStartingPrice
    {
        get { return _startingStockPrice; }
        set
        {
            _startingStockPrice = value;
        }
    }

    public float StockVolatility
    {
        get { return _stockVolatility;}
        set
        {
            _stockVolatility = value;
        }
    }

    public float StockCurrentPrice
    {
        get { return _currentStockPrice; }
        set
        {
            _currentStockPrice = value;
        }
    }
    public int GafStockAmount
    {
        get { return _GafStockAmount; }
        set
        {
            _GafStockAmount = value;
        }
    }
    public  int GnomeStockAmount
    {
        get { return _GnomeStockAmount; }
        set
        {
            _GnomeStockAmount = value;
        }
    }

    public int NahWeUpStockAmount
    {
        get { return _NahWeUpStockAmount;}
        set
        {
            _NahWeUpStockAmount = value;
        }
    }
}
