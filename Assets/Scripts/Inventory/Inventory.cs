using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс реализующий функционал инвентаря
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    [SerializeField] private Player _player;
    [SerializeField] private InventoryUI _inventoryUI;
    public InventoryData InventoryData => _inventoryData;
    public Player Player => _player;
    public InventoryUI InventoryUI => _inventoryUI;

    public bool AddItem(Item item, int count = 1)
    {
        if (item != null && count > 0)
        {
            for (int i = 0; i < InventoryData.Slots.Count; i++)
            {
                if (InventoryData.Slots[i].Item == item && InventoryData.Slots[i].CanAddItem())
                {
                    InventoryData.Slots[i].AddItem(item, count);
                    return true;
                }
            }

            for (int i = 0; i < InventoryData.Slots.Count; i++)
            {
                if (InventoryData.Slots[i].Item == null)
                {
                    InventoryData.Slots[i].AddItem(item, count);
                    return true;
                }
            }
        }
        return false;
    }

    public bool RemoveItem(Item item, int count = 1)
    {
        if (item != null && count > 0)
        {
            for (int i = 0; i < InventoryData.Slots.Count; i++)
            {
                if (InventoryData.Slots[i].Item == item && InventoryData.Slots[i].Count - count > 0)
                {
                    InventoryData.Slots[i].Count -= count;
                    return true;
                }
                else if (InventoryData.Slots[i].Item == item && InventoryData.Slots[i].Count - count == 0)
                {
                    InventoryData.Slots[i].Item = null;
                    InventoryData.Slots[i].Count = 0;
                    return true;
                }
                else if ((InventoryData.Slots[i].Item == item && InventoryData.Slots[i].Count - count < 0 && CheckCanRemove(item, count)) || item is ToolItem)
                {
                    Item currentItem = InventoryData.Slots[i].Item;
                    int currentCount = count - InventoryData.Slots[i].Count;

                    InventoryData.Slots[i].Item = null;
                    InventoryData.Slots[i].Count = 0;

                    RemoveItem(currentItem, currentCount);
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCanRemove(Item item, int count = 1)
    {
        int countItems = 0;

        if (item != null && count > 0)
        {
            for (int i = 0; i < InventoryData.Slots.Count; i++)
            {
                if (InventoryData.Slots[i].Item == item)
                {
                    countItems += InventoryData.Slots[i].Count;
                }
            }
        }

        if(countItems >= count)
            return true;
        else
            return false;
    }
}
