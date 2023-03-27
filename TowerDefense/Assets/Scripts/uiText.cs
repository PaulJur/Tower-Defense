using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiText : MonoBehaviour
{
    private Spawner spawn;
    private StockManager stock;
    private Gold gold;

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
    [SerializeField]
    private TextMeshProUGUI GoldAmount;
    [SerializeField]
    private TextMeshProUGUI GafStockAmount;

    private void Start()
    {
        stock = GetComponent<StockManager>();
        gold = GetComponent<Gold>();

    }



    void Update()
    {
        roundCount.text = "Current Round: " + Spawner.currentRound.ToString();

        roundTimer.text = "" + Spawner.roundDelay.ToString("f0");

        upcomingEnemies.text = "Upcoming Enemies: " + Spawner.currentEnemies.ToString();

        GafStockPrice.text = $"Stock Name: {stock.GafStock.StockName} Current stock price: {stock.GafStock.StockCurrentPrice}";

        GnomeStockPrice.text = $"Stock Name: {stock.GnomeStock.StockName} Current stock price: {stock.GnomeStock.StockCurrentPrice}";

        NahWeGoingUpPrice.text = $"Stock Name: {stock.NahWeGoingUp.StockName} Current stock price: {stock.NahWeGoingUp.StockCurrentPrice}";

        GafStockAmount.text = $"GAF amount: {stock.GafStock.GafStockAmount}";

        GoldAmount.text = $"Gold Amount: {gold.CurrentGoldAmount}";



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
