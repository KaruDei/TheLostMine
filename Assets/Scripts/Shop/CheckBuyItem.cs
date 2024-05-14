using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ����� �������� ������� �� ������� � ������� ��� �������
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
