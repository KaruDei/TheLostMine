using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс хранения информации о инвентаре
/// </summary>
[CreateAssetMenu(fileName = "InventoryData", menuName = "Mine/Data/Inventory", order = 0)]
public class InventoryData : ScriptableObject
{
    public string InventoryName;
    public int MaxSlots;

    public List<Slot> Slots;

    [Header("StartItems")]
    public List<Item> StartItems;
    public List<int> StartItemsCount;

    public void Save()
    {
        PlayerPrefs.SetString(InventoryName, JsonUtility.ToJson(this));
    }

    public bool Load()
    {
        Slots.Clear();
        if (PlayerPrefs.HasKey(InventoryName))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(InventoryName), this);
            return true;
        }
        return false;
    }

    public void Clear()
    {
        Slots.Clear();
    }
}
