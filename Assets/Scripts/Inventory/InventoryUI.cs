using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс отображаемого инвентаря
/// </summary>

public class InventoryUI : MonoBehaviour
{
    [Header("Invenotry")]
    [SerializeField] private Inventory _inventory;
    [Header("Level")]
    [SerializeField] private TextMeshProUGUI _levelText;
    [Header("Expirience")]
    [SerializeField] private RectTransform _expBar;
    [SerializeField] private TextMeshProUGUI _expText;

    public List<SlotUI> slotsUI;

    public void Setup()
    {
        UpdateLevel();
        UpdateExp();

        if (_inventory.InventoryData.Slots.Count == slotsUI.Count)
        {
            for (int i = 0; i < _inventory.InventoryData.Slots.Count; i++)
            {
                if (_inventory.InventoryData.Slots[i] != null && _inventory.InventoryData.Slots[i].Item != null)
                {
                    slotsUI[i].SetItem(_inventory.InventoryData.Slots[i]);
                }
                else
                {
                    slotsUI[i].SetEmpty();
                }
            }
        }
        else
        {
            Debug.LogError($"Количество слотов не совпадает: {_inventory.InventoryData.Slots.Count} != {slotsUI.Count}");
        }
        
    }

    public void UpdateLevel()
    {
        _levelText.text = $"Уровень {_inventory.Player.PlayerData.level}";
    }

    public void UpdateExp()
    {
        _expText.text = $"{_inventory.Player.PlayerData.exp}/{_inventory.Player.PlayerData.maxExp}";

        float newExp = (float)_inventory.Player.PlayerData.exp / (float)_inventory.Player.PlayerData.maxExp;
        _expBar.localScale = new Vector3(newExp, 1f, 1f);
    }
}
