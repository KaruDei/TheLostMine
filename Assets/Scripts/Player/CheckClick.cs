using UnityEngine;

public class CheckClick : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _actionButton;
    [SerializeField] private ShopUI _shopUI;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;

    public bool ShopTrigger;
    public bool WellspringTrigger;
    public bool MineTrigger;
    public Mine Mine;
    public bool IsTool;

    private void FixedUpdate()
    {
        if (!ShopTrigger && !WellspringTrigger && !MineTrigger && IsTool)
        {
            if (!_actionButton.activeSelf)
            {
                _actionButton.SetActive(true);
            }
        }
        else if (!ShopTrigger && !WellspringTrigger && MineTrigger)
        {
            if (_actionButton.activeSelf)
            {
                _actionButton.SetActive(true);
            }
        }
        else if (!ShopTrigger && !WellspringTrigger && !MineTrigger && !IsTool)
        {
            if (_actionButton.activeSelf)
            {
                _actionButton.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!ShopTrigger && !WellspringTrigger)
        {
            if (collision.tag == "Shop")
            {
                ShopTrigger = true;
                _actionButton.SetActive(true);
            }

            else if (collision.tag == "Wellspring")
            {
                WellspringTrigger = true;
                _actionButton.SetActive(true);
            }

            else if (collision.tag == "Mine")
            {
                MineTrigger = true;
                Mine = collision.GetComponent<Mine>();
                _actionButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Shop" && ShopTrigger && !WellspringTrigger && !IsTool)
        {
            ShopTrigger = false;
            _actionButton.SetActive(false);
        }
        else if (collision.tag == "Wellspring" && WellspringTrigger && !ShopTrigger && !IsTool && _player.Inventory.InventoryData.Slots[0].Item is ToolItem ToolItem && ToolItem.CanFill)
        {
            WellspringTrigger = false;
            _actionButton.SetActive(false);
        }
    }

    public void Action()
    {
        if (ShopTrigger && !WellspringTrigger)
        {
            _buttons.SetActive(false);
            _shopUI.gameObject.SetActive(true);
            _shopUI.Setup();
            return;
        }
        else if (!ShopTrigger && WellspringTrigger)
        {
            _buttons.SetActive(false);
            if (_player.Inventory.InventoryData.Slots[0].Item is ToolItem ToolItem && ToolItem.CanFill && ToolItem.ToolType == ToolType.BOTTLE)
            {
                _player.Inventory.InventoryData.Slots[0].IsFill = true;
            }
            return;
        }
        else if (!ShopTrigger && !WellspringTrigger && IsTool)
        {
            Ray ray = new Ray(_camera.transform.position + _camera.transform.forward * 2f, _camera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f, _layerMask))
            {
                MineResource mineResource = hit.collider.transform.parent.GetComponent<MineResource>();
                if (_player.Inventory.InventoryData.Slots[0].Item is ToolItem ToolItem && ToolItem.ToolType == mineResource.Item.ExtractToolType)
                {
                    mineResource.GetResource(_player);
                }
            }
        }
    }
}
