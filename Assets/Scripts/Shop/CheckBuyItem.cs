using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс проверки нажатия на элемент и попытка его покупки
/// </summary>

public class CheckBuyItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Shop _shop;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<SlotUI>() is SlotUI SlotUI && SlotUI.Slot != null)
        {
            _shop.BuyItem(SlotUI.Slot.Item);
        }
    }
}
