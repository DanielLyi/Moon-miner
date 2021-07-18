using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Furniture : MonoBehaviour
{
    [SerializeField] float price;
    [FormerlySerializedAs("sellController")] [SerializeField] SellFurnitureController sellFurnitureController;
    bool selled = false;
    public float GetPrice()
    {
        return price;
    }

    public void SetSelled(bool selled)
    {
        this.selled = selled;
    }

    public bool GetSelled()
    {
        return selled;
    }
}
