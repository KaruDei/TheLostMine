using System.Collections.Generic;
using UnityEngine;

public class CheckActiveItem : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<GameObject> _toolList;
    [SerializeField] private CheckClick _checkClick;

    public void SetVisableTool()
    {
        SetUnVisableTool();
        if (_inventory.InventoryData.Slots[0] != null && _inventory.InventoryData.Slots[0].Item != null)
        {
            if (_inventory.InventoryData.Slots[0].Item is ToolItem ToolItem)
            {
                _checkClick.IsTool = true;
                switch (ToolItem.ToolType)
                {
                    case ToolType.AXE:
                        _toolList[0].SetActive(true);
                        break;
                    case ToolType.PICKAXE:
                        _toolList[1].SetActive(true);
                        break;
                    case ToolType.SHOVEL:
                        _toolList[2].SetActive(true);
                        break;
                    case ToolType.TOUCH:
                        _toolList[3].SetActive(true);
                        break;
                    case ToolType.BUCKET:
                        _toolList[4].SetActive(true);
                        break;
                    case ToolType.BOTTLE:
                        _toolList[5].SetActive(true);
                        break;
                    default:
                        Debug.LogError("Неопознаный инструмент");
                        break;
                }
            }
            else
            {
                _checkClick.IsTool = false;
            }
        }
        else
        {
            _checkClick.IsTool = false;
        }
    }

    private void SetUnVisableTool()
    {
        foreach (var obj in _toolList)
        {
            obj.SetActive(false);
        }
    }
}
