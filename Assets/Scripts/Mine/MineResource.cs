using UnityEngine;

public class MineResource : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    private float _respawnTime;
    private int _resourceCount;

    public Item Item;
    public bool IsExtracted;

    private void Start()
    {
        _respawnTime = 0f;
        _resourceCount = Item.ResourceCount;
        IsExtracted = false;
    }

    private void Update()
    {
        if (IsExtracted)
        {
            _respawnTime += Time.deltaTime;
            if (_respawnTime >= Item.RespawnTime)
            {
                _respawnTime = 0;
                _resourceCount = Item.ResourceCount;
                IsExtracted = false;
                _model.SetActive(true);
            }
        }
    }

    public void GetResource(Player player)
    {
        if (!IsExtracted)
        {
            if (player.Inventory.AddItem(Item))
            {
                player.AddExp(Item.ResourceExp);

                player.Inventory.InventoryData.Slots[0].ToolStrength--;
                if (player.Inventory.InventoryData.Slots[0].ToolStrength <= 0)
                {
                    player.Inventory.RemoveItem(player.Inventory.InventoryData.Slots[0].Item);
                    player.CheckActiveItem.SetVisableTool();
                }

                _resourceCount--;
                if (_resourceCount <= 0)
                {
                    IsExtracted = true;
                    _model.SetActive(false);
                }
            }
        }
    }
}
