using UnityEngine;

/// <summary>
/// Класс реализующий функционал магазина
/// </summary>

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _badBuyFieldAnimator;
    [SerializeField] private ShopInventory _shopInventory;
    public ShopInventory ShopInventory => _shopInventory;

    public bool BuyItem(Item Item)
    {
        if (Item != null)
        {
            if (_player.PlayerData.money - Item.BuyPrice >= 0)
            {
                _player.Inventory.AddItem(Item);
                _player.RemoveMoney(Item.BuyPrice);
                return true;
            }
            else {
                _badBuyFieldAnimator.SetTrigger("Play");
            }
        }
        return false;
    }
}
