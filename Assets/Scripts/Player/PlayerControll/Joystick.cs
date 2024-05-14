using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 _direction;
    private Vector2 _startPosition;
    private Vector2 _offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount > 0) _startPosition = Input.GetTouch(0).position;
        else _startPosition = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 0) _offset = Input.GetTouch(0).position - _startPosition;
        else _offset =new Vector2(Input.mousePosition.x, Input.mousePosition.y) - _startPosition;
        _direction = _offset.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _direction = Vector2.zero;
        _offset = Vector2.zero;
    }

    public Vector3 GetDirection()
    {
        return new Vector3(_direction.x, 0f , _direction.y);
    }
}
