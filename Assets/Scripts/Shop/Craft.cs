using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Slot> _items;
    [SerializeField] private List<SlotUI> _inventorySlots;

    public List<SlotUI> craftSlots;

    private void Start()
    {
        for (int i = 0; i < craftSlots.Count; i++)
        {
            craftSlots[i].SetEmpty();
        }
    }

    private void FixedUpdate()
    {
        if (craftSlots[0].Slot != null && craftSlots[1].Slot != null && craftSlots[0].Slot.Item != null && craftSlots[1].Slot.Item != null)
        {
            if ((craftSlots[0].Slot.Item.Name == "Iron" && craftSlots[1].Slot.Item.Name == "Copper") || (craftSlots[0].Slot.Item.Name == "Copper" && craftSlots[1].Slot.Item.Name == "Iron"))
            {
                craftSlots[2].SetItem(_items[4]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "Silver" && craftSlots[1].Slot.Item.Name == "Iron") || (craftSlots[0].Slot.Item.Name == "Iron" && craftSlots[1].Slot.Item.Name == "Silver"))
            {
                craftSlots[2].SetItem(_items[5]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "Silver" && craftSlots[1].Slot.Item.Name == "Gold") || (craftSlots[0].Slot.Item.Name == "Gold" && craftSlots[1].Slot.Item.Name == "Silver"))
            {
                craftSlots[2].SetItem(_items[6]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "Pine" && craftSlots[0].Slot.Count >= 4 && craftSlots[1].Slot.Item.Name == "Steel") || (craftSlots[0].Slot.Item.Name == "Steel" && craftSlots[1].Slot.Item.Name == "Pine" && craftSlots[1].Slot.Count >= 4))
            {
                craftSlots[2].SetItem(_items[7]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "Bronze" && craftSlots[1].Slot.Item.Name == "SilverClear") || (craftSlots[0].Slot.Item.Name == "SilverClear" && craftSlots[1].Slot.Item.Name == "Bronze"))
            {
                craftSlots[2].SetItem(_items[8]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "Steel" && craftSlots[1].Slot.Item.Name == "Bronze") || (craftSlots[0].Slot.Item.Name == "Bronze" && craftSlots[1].Slot.Item.Name == "Steel"))
            {
                craftSlots[2].SetItem(_items[9]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "IronCopper" && craftSlots[1].Slot.Item.Name == "GoldClear") || (craftSlots[0].Slot.Item.Name == "GoldClear" && craftSlots[1].Slot.Item.Name == "IronCopper"))
            {
                craftSlots[2].SetItem(_items[10]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "IronCopper" && craftSlots[1].Slot.Item.Name == "SilverIron") || (craftSlots[0].Slot.Item.Name == "SilverIron" && craftSlots[1].Slot.Item.Name == "IronCopper"))
            {
                craftSlots[2].SetItem(_items[11]);
            }
            else if ((craftSlots[0].Slot.Item.Name == "IronCopper" && craftSlots[1].Slot.Item.Name == "SilverGold") || (craftSlots[0].Slot.Item.Name == "SilverGold" && craftSlots[1].Slot.Item.Name == "IronCopper"))
            {
                craftSlots[2].SetItem(_items[12]);
            }
            else
            {
                craftSlots[2].SetEmpty();
            }
        }
        else if (craftSlots[0].Slot != null && craftSlots[0].Slot.Item != null && (craftSlots[1].Slot == null || craftSlots[1].Slot.Item == null))
        {
            if (craftSlots[0].Slot.Item.Name == "Iron")
            {
                craftSlots[2].SetItem(_items[0]);
            }
            else if (craftSlots[0].Slot.Item.Name == "Copper")
            {
                craftSlots[2].SetItem(_items[1]);
            }
            else if (craftSlots[0].Slot.Item.Name == "Silver")
            {
                craftSlots[2].SetItem(_items[2]);
            }
            else if (craftSlots[0].Slot.Item.Name == "Gold")
            {
                craftSlots[2].SetItem(_items[3]);
            }
            else
            {
                craftSlots[2].SetEmpty();
            }
        }
        else if (craftSlots[1].Slot != null && craftSlots[1].Slot.Item != null && (craftSlots[0].Slot == null || craftSlots[0].Slot.Item == null))
        {
            if (craftSlots[1].Slot.Item.Name == "Iron")
            {
                craftSlots[2].SetItem(_items[0]);
            }
            else if (craftSlots[1].Slot.Item.Name == "Copper")
            {
                craftSlots[2].SetItem(_items[1]);
            }
            else if (craftSlots[1].Slot.Item.Name == "Silver")
            {
                craftSlots[2].SetItem(_items[2]);
            }
            else if (craftSlots[1].Slot.Item.Name == "Gold")
            {
                craftSlots[2].SetItem(_items[3]);
            }
            else
            {
                craftSlots[2].SetEmpty();
            }
        }
        else
        {
            craftSlots[2].SetEmpty();
        }
        
    }

    public void Setup()
    {
        if (_player.Inventory.InventoryData.Slots.Count - 1 == _inventorySlots.Count)
        {
            for (int i = 1; i < _player.Inventory.InventoryData.Slots.Count; i++)
            {
                if (_player.Inventory.InventoryData.Slots[i] != null && _player.Inventory.InventoryData.Slots[i].Item != null)
                {
                    _inventorySlots[i - 1].SetItem(_player.Inventory.InventoryData.Slots[i]);
                }
                else
                {
                    _inventorySlots[i - 1].SetEmpty();
                }
            }
        }
        else
        {
            Debug.LogError($"Количество слотов не совпадает: {_player.Inventory.InventoryData.Slots.Count} != {_inventorySlots.Count}");
        }
    }

    public void CraftItem()
    {
        if (_player.Inventory.AddItem(craftSlots[2].Slot.Item, craftSlots[2].Slot.Count))
        {
            if (craftSlots[0].Slot != null && craftSlots[1].Slot != null && craftSlots[0].Slot.Item != null && craftSlots[1].Slot.Item != null)
            {
                _player.Inventory.RemoveItem(craftSlots[0].Slot.Item);
                _player.Inventory.RemoveItem(craftSlots[1].Slot.Item);
                SetEmpty();
            }
            else if (craftSlots[0].Slot != null && craftSlots[0].Slot.Item != null && (craftSlots[1].Slot == null || craftSlots[1].Slot.Item == null))
            {
                _player.Inventory.RemoveItem(craftSlots[0].Slot.Item);
                SetEmpty();
            }
            else if (craftSlots[1].Slot != null && craftSlots[1].Slot.Item != null && (craftSlots[0].Slot == null || craftSlots[0].Slot.Item == null))
            {
                _player.Inventory.RemoveItem(craftSlots[1].Slot.Item);
                SetEmpty();
            }

            _player.Inventory.InventoryUI.Setup();
            Setup();
        }
    }

    public void SetEmpty()
    {
        craftSlots[0].SetEmpty();
        craftSlots[1].SetEmpty();
        craftSlots[2].SetEmpty();
    }
}
