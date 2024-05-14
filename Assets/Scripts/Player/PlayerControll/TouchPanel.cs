using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 _touchPosition;
    private Vector2 _touchDirection;
    private bool _pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position;
        _pressed = true;
    }

    private void FixedUpdate()
    { 
        if (_pressed)
        {
            if (Input.touchCount > 0)
            {
                _touchDirection = Input.GetTouch(Input.touchCount - 1).position - _touchPosition;
                _touchPosition = Input.GetTouch(Input.touchCount - 1).position;
            }
            else
            {
                Vector2 position = new(Input.mousePosition.x, Input.mousePosition.y);
                _touchDirection = position - _touchPosition;
                _touchPosition = position;
            }
        }
        else
        {
            _touchDirection = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    public Vector2 GetTouchDirection()
    {
        return _touchDirection;
    }
}
