using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс реализующий функцию выбора предмета
/// </summary>

public class SelectItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SelectItems _selectItems;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.GetComponent<SlotUI>() is SlotUI SlotUI)
        {
            if (SlotUI.name == "ActiveItem")
            {
                _selectItems.SelectItem(0);
                return;
            }
            else if (SlotUI.tag == "CraftSlot")
            {
                if (SlotUI.transform.GetSiblingIndex() == 2 && SlotUI.Slot != null && SlotUI.Slot.Item != null)
                {
                    _selectItems.CraftItem();
                    return;
                }
                else if (_selectItems.selected)
                {
                    _selectItems.SelectCraftItem(SlotUI.transform.GetSiblingIndex());
                    return;
                }
                else if (SlotUI.Slot != null && SlotUI.Slot.Item != null)
                {
                    SlotUI.SetEmpty();
                    return;
                }
            }
            else
            {
                
                _selectItems.SelectItem(SlotUI.transform.GetSiblingIndex() + 1);
            }

            
        }
    }
}
