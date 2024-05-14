/// <summary>
/// Класс слота инвентаря
/// </summary>
[System.Serializable]
public class Slot
{
    public Item Item;
    public int Count;
    public bool IsFill;
    public int ToolStrength;

    /// <summary>
    /// Класс конструктор слота инвентаря
    /// </summary>
    public Slot()
    {
        Item = null;
        Count = 0;
        ToolStrength = 0;
        IsFill = false;
    }

    public bool CanAddItem()
    {
        if (Item.CanStack && Count < Item.StackCapacity)
        {
            return true;
        }
        return false;
    }

    public void AddItem(Item Item, int Count = 1)
    {
        this.Item = Item;
        if (Item is ToolItem ToolItem)
        {
            ToolStrength = ToolItem.ToolStrength;
            this.Count = 1;
        }
        else
            this.Count += Count;
    }
}
