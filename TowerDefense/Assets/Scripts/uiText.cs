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

    #region StockNames
    [SerializeField]
    private TextMeshProUGUI GafStockName;
    [SerializeField]
    private TextMeshProUGUI GnomeStockName;
    [SerializeField]
    private TextMeshProUGUI NahWeGoingUpName;
    #endregion

    [SerializeField]
    private TextMeshProUGUI GoldAmount;

    [SerializeField] AudioSource roundCountDownSound;

    #region StockAmount
    [SerializeField]
    private TextMeshProUGUI GafStockAmount;
    [SerializeField]
    private TextMeshProUGUI GnomeStockAmount;
    [SerializeField]
    private TextMeshProUGUI NahWeGoingUpStockAmount;
    #endregion

    #region StockPrice
    [SerializeField]
    private TextMeshProUGUI GafPrice;
    [SerializeField]
    private TextMeshProUGUI GnomePrice;
    [SerializeField]
    private TextMeshProUGUI NahWeGoingUpPrice;
    #endregion

    private void Start()
    {
        stock = GetComponent<StockManager>();
        gold = GetComponent<Gold>();
        spawn = GetComponent<Spawner>();

    }



    void Update()
    {
        #region otherText
        roundCount.text = "Current Round: " + Spawner.currentRound.ToString();

        roundTimer.text = "" + spawn.roundDelay.ToString("f0");

        upcomingEnemies.text = "Upcoming Enemies: " + Spawner.enemiesToSpawn.ToString();

        GoldAmount.text = $"Gold Amount: {gold.CurrentGoldAmount}";

        #endregion
        #region StockNames
        GafStockName.text = $"Stock Name: {stock.GafStock.StockName}";

        GnomeStockName.text = $"Stock Name: {stock.GnomeStock.StockName}";

        NahWeGoingUpName.text = $"Stock Name: {stock.NahWeGoingUp.StockName}";
        #endregion
        #region StockAmount
        GafStockAmount.text = $"GAF Stock: {stock.GafStock.GafStockAmount}";

        GnomeStockAmount.text = $"Gnome Stock: {stock.GnomeStock.GnomeStockAmount}";

        NahWeGoingUpStockAmount.text = $"WeUp Stock: {stock.NahWeGoingUp.NahWeUpStockAmount}";
        #endregion
        #region Stockprices
        GafPrice.text = $"Price: {stock.GafStock.StockCurrentPrice}";

        GnomePrice.text = $"Price: {stock.GnomeStock.StockCurrentPrice}";

        NahWeGoingUpPrice.text = $"Price: {stock.NahWeGoingUp.StockCurrentPrice}";
        #endregion




        if (spawn.roundDelay > 0) //If round timer is above 0 countdown;
        {
            spawn.roundDelay-=Time.deltaTime;

            if (spawn.roundDelay < 3 && !roundCountDownSound.isPlaying)
            {
                roundCountDownSound.Play();
            }
        }
        else
        {
            spawn.roundDelay = 0;
        }

        
    }
}
