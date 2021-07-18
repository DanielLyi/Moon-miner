using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SellFurnitureController : MonoBehaviour
{
    [SerializeField] private PlayerBalance playerBalance;
    [SerializeField] private TextMeshProUGUI text;
    private float _resultingMoney;
    private Furniture _selectedFurniture;
    private Image _selectedFurniture1;



    public void SellFurniture()
    {
        if (!_selectedFurniture.GetSelled())
        {
            playerBalance.money += _selectedFurniture.GetPrice();
            Color lowOpacity = new Color(1, 1, 1);
            lowOpacity.a = 0.3f;
            _selectedFurniture1.color = lowOpacity;
            _selectedFurniture.SetSelled(true);
        }
    }

    public void BuyFurniture()
    {
        if (_selectedFurniture.GetSelled())
        {
            if (playerBalance.money >= _selectedFurniture.GetPrice())
            {
                playerBalance.money -= _selectedFurniture.GetPrice();
                Color highOpacity = new Color(1, 1, 1);
                highOpacity.a = 1f;
                _selectedFurniture1.color = highOpacity;
                _selectedFurniture.SetSelled(false);
            }
        }
    }

    public void SetSelectedFurniture(Furniture furniture)
    {
        _selectedFurniture = furniture;
    }
    public void SetSelectedFurniture1(Image furniture)
    {
        _selectedFurniture1 = furniture;
    }
}
