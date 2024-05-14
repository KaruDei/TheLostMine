using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;

    public float timeToDrink = 0f;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        timeToDrink += Time.deltaTime;
        if (timeToDrink > 60)
        {
            timeToDrink = 0f;
            if (_player.PlayerData.thirsty > 0)
            {
                _player.PlayerData.thirsty--;
                _player.UpdateWaterBar();
            }
        }
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PlayerData") && PlayerPrefs.HasKey(_inventory.InventoryData.InventoryName))
        {
            _player.PlayerData.Load();
            _inventory.InventoryData.Load();
        }
        else
        {
            _player.PlayerData.Clear();
            _inventory.InventoryData.Clear();

            for (int i = 0; i < _inventory.InventoryData.MaxSlots; i++)
            {
                _inventory.InventoryData.Slots.Add(new Slot());
            }

            if (_inventory.InventoryData.StartItems.Count != 0 && _inventory.InventoryData.StartItems.Count == _inventory.InventoryData.StartItemsCount.Count)
            {
                for (int i = 0; i < _inventory.InventoryData.StartItems.Count; i++)
                {
                    _inventory.AddItem(_inventory.InventoryData.StartItems[i], _inventory.InventoryData.StartItemsCount[i]);
                }
            }
        }
    }

    public void Save()
    {
        _player.PlayerData.Save();
        _inventory.InventoryData.Save();
    }

    public void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }

    public void QuitInMainMenu()
    {
        LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
