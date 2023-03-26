using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour
{

    public Stock GnomeStock;
    public Stock GafStock;
    public Stock NahWeGoingUp;

    void Start()
    {
        GnomeStock = new Stock(10f, 1f, "Gnome Stock");
        GafStock = new Stock(10f, 2f, "GAF Stock");
        NahWeGoingUp = new Stock(10f, 1.5f, "NahWeGoingUp Stock");
    }

    void Update()
    {
        
    }
}
