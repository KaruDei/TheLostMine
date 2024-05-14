using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Mine/Items/ToolItem", order = 0)]
public class ToolItem : Item
{
    [Header("Tool")]
    public ToolType ToolType;
    public bool CanBroken;
    public int ToolStrength;

    public bool CanFill;
    public Sprite EmpySprite;
    public Sprite FillSprite;

    private void OnValidate()
    {
        if (!CanBroken || ToolStrength <= 0)
        {
            ToolStrength = 1;
        }

        if (!CanFill)
        {
            EmpySprite = null;
            FillSprite = null;
        }
    }
}

public enum ToolType
{
    AXE,
    PICKAXE,
    BOTTLE,
    BUCKET,
    SHOVEL,
    TOUCH,
    NONE,
}
