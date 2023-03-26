using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiText : MonoBehaviour
{
    Spawner spawn;
    StockManager stock;
    [SerializeField]
    private TextMeshProUGUI roundCount;
    [SerializeField]
    private TextMeshProUGUI roundTimer;
    [SerializeField]
    private TextMeshProUGUI upcomingEnemies;
    [SerializeField]
    private TextMeshProUGUI GafStockPrice;
    [SerializeField]
    private TextMeshProUGUI GnomeStockPrice;
    [SerializeField]
    private TextMeshProUGUI NahWeGoingUpPrice;

    private void Start()
    {
        stock = GetComponent<StockManager>();
    }

    void Update()
    {
        roundCount.text = "Current Round: " + Spawner.currentRound.ToString();

        roundTimer.text = "" + Spawner.roundDelay.ToString("f0");

        upcomingEnemies.text = "Upcoming Enemies: " + Spawner.currentEnemies.ToString();

        GafStockPrice.text = $"Stock Name: {stock.GafStock.StockName} Current stock price: {stock.GafStock.StockCurrentPrice}";

        GnomeStockPrice.text = $"Stock Name: {stock.GnomeStock.StockName} Current stock price: {stock.GnomeStock.StockCurrentPrice}";

        NahWeGoingUpPrice.text = $"Stock Name: {stock.NahWeGoingUp.StockName} Current stock price: {stock.NahWeGoingUp.StockCurrentPrice}";



        if (Spawner.roundDelay > 0)
        {
            Spawner.roundDelay-=Time.deltaTime;
        }
        else
        {
            Spawner.roundDelay = 0;
        }
    }
}
