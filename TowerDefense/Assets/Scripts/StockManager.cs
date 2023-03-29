using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour
{
    private Stock stock;
    private Gold gold;

    public Stock GnomeStock;
    public Stock GafStock;
    public Stock NahWeGoingUp;

    void Start()
    {
        GnomeStock = new Stock(10f, 1f, "Gnome Stock");
        GafStock = new Stock(10f, 2f, "GAF Stock");
        NahWeGoingUp = new Stock(10f, 1.5f, "WeUp Stock");

        gold = GetComponent<Gold>();

    }

   public void BuyGafStock()
    {
        if (gold.CurrentGoldAmount < GafStock.StockCurrentPrice)
        {
            Debug.Log("Not enough gold!");
        }
        else
        {
            GafStock.GafStockAmount++;
            gold.RemoveGold(GafStock.StockCurrentPrice);
        }
    }

    public void SellGafStock()
    {
        if (GafStock.GafStockAmount <= 0)
        {
            Debug.Log("You dont have any stock!");
        }
        else
        {
            GafStock.GafStockAmount--;
            gold.AddGold(GafStock.StockCurrentPrice);
        }
    }

    public void BuyGnomeStock()
    {
        
        if (gold.CurrentGoldAmount < GnomeStock.StockCurrentPrice)
        {
            Debug.Log("Not enough gold!");
        }
        else
        {
            GnomeStock.GnomeStockAmount++;
            gold.RemoveGold(GnomeStock.StockCurrentPrice);
        }
    }

    public void SellGnomeStock()
    {
        if (GnomeStock.GnomeStockAmount <= 0)
        {
            Debug.Log("You dont have any stock!");
        }
        else
        {
            GnomeStock.GnomeStockAmount--;
            gold.AddGold(GnomeStock.StockCurrentPrice);
        }
    }

    public void BuyNahWeUpStock()
    {

        if (gold.CurrentGoldAmount < NahWeGoingUp.StockCurrentPrice)
        {
            Debug.Log("Not enough gold!");
        }
        else
        {
            NahWeGoingUp.NahWeUpStockAmount++;
            gold.RemoveGold(NahWeGoingUp.StockCurrentPrice);
        }
    }

    public void SellNahWeUpStock()
    {
        if (NahWeGoingUp.NahWeUpStockAmount <= 0)
        {
            Debug.Log("You dont have any stock!");
        }
        else
        {
            NahWeGoingUp.NahWeUpStockAmount--;
            gold.AddGold(NahWeGoingUp.StockCurrentPrice);
        }
    }


}
