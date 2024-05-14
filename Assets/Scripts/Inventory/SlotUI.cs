using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Класс отображаемого слота
/// </summary>
public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _text;

    public Slot Slot;

    public void SetEmpty()
    {
        _icon.sprite = null;
        _icon.color = Color.clear;
        _text.text = "";
        Slot = null;
    }

    public void SetItem(Slot Slot)
    {
        if (Slot.Item == null) return;

        this.Slot = Slot;
        _icon.color = Color.white;

        if (Slot.Item is ToolItem ToolItem)
        {
            if (ToolItem.CanFill)
            {
                if (Slot.IsFill)
                    _icon.sprite = ToolItem.FillSprite;
                else
                    _icon.sprite = ToolItem.EmpySprite;
            }
            else
            {
                _icon.sprite = ToolItem.Icon;
            }

            _text.text = Slot.ToolStrength.ToString();
        }
        else
        {
            _icon.sprite = Slot.Item.Icon;
            _text.text = $"x{Slot.Count}";
        }
    }

    public void SetBuyShopItem(Slot Slot)
    {
        if (Slot.Item == null) return;
        _icon.sprite = Slot.Item.Icon;
        _icon.color = Color.white;
        _text.text = $"{Slot.Item.BuyPrice}";
        this.Slot = Slot;
    }

    public void SetSellShopItem(Slot Slot)
    {
        if (Slot.Item == null) return;
        _icon.sprite = Slot.Item.Icon;
        _icon.color = Color.white;
        _text.text = $"{Slot.Item.SellPrice}";
        this.Slot = Slot;
    }
}
