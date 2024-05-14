using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Mine/Items/Item", order = 0)]
public class Item : ScriptableObject
{
    [Header("Settings")]
    public string Name;
    public Sprite Icon;
    public int Level;

    [Header("Stack")]
    public bool CanStack;
    public int StackCapacity;

    [Header("Buy")]
    public bool CanBuy;
    public int BuyPrice;
    public int BuyCount;

    [Header("Sell")]
    public bool CanSell;
    public int SellPrice;

    [Header("Extract")]
    public bool CanExtract;
    public float RespawnTime;
    public int ResourceCount;
    public int ResourceExp;
    public ToolType ExtractToolType;

    private void OnValidate()
    {
        if (!CanStack || StackCapacity <= 0)
        {
            StackCapacity = 1;
        }

        if (!CanBuy)
        {
            BuyPrice = 0;
            BuyCount = 0;
        }

        if (!CanSell)
        {
            SellPrice = 0;
        }

        if (!CanExtract)
        {
            RespawnTime = 0;
            ResourceCount = 0;
            ResourceExp = 0;
            ExtractToolType = ToolType.NONE;
        }
    }
}
