using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopInventoryData", menuName = "Mine/Data/ShopInventory", order = 0)]
public class ShopInventory : ScriptableObject
{
    public List<Slot> BuySlots;
    public List<Slot> SellSlots;
}
