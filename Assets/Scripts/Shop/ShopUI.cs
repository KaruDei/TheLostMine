using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс отображения магазина
/// </summary>

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Player _player;
    [SerializeField] private List<SlotUI> BuySlotsUI;
    [SerializeField] private List<SlotUI> SellSlotsUI;
    [SerializeField] private TextMeshProUGUI _moneyText;

    private int BuyCount = 0;
    private int SellCount = 0;

    private void FixedUpdate()
    {
        _moneyText.text = $"Монет: {_player.PlayerData.money}";
    }

    public void Setup()
    {
        ClearShopSlots();
        if (BuySlotsUI.Count == 15 && SellSlotsUI.Count == 15)
        {
            if (_shop.ShopInventory.BuySlots.Count > 0 && _shop.ShopInventory.BuySlots.Count <= BuySlotsUI.Count)
            {
                for (int i = 0; i < _shop.ShopInventory.BuySlots.Count; i++)
                {
                    if (_shop.ShopInventory.BuySlots[i].Item.Level <= _player.PlayerData.level)
                    {
                        BuySlotsUI[BuyCount].SetBuyShopItem(_shop.ShopInventory.BuySlots[i]);
                        BuyCount++;
                    }
                }
            }

            if (_shop.ShopInventory.SellSlots.Count > 0 && _shop.ShopInventory.SellSlots.Count <= SellSlotsUI.Count)
            {
                for (int i = 0; i < _shop.ShopInventory.SellSlots.Count; i++)
                {
                    if (_shop.ShopInventory.SellSlots[i].Item.Level <= _player.PlayerData.level)
                    {
                        SellSlotsUI[SellCount].SetSellShopItem(_shop.ShopInventory.SellSlots[i]);
                        SellCount++;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Недостаточное количество слотов");
        }
    }

    public void ClearShopSlots()
    {
        for (int i = 0; i < BuySlotsUI.Count && i < SellSlotsUI.Count; i++)
        {
            BuySlotsUI[i].SetEmpty();
            SellSlotsUI[i].SetEmpty();
            BuyCount = 0;
            SellCount = 0;
        }
    }
}
