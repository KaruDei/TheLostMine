using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс реализующий функционал игрока
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private RectTransform _expBar;
    [SerializeField] private List<RectTransform> _waterBarElems;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;
    public Inventory Inventory => _inventory;

    public CheckActiveItem CheckActiveItem;

    private void Start()
    {
        UpdateWaterBar();
        UpdateExpBar();

        if (!_playerData.Load())
        {
            _playerData.money = 400;
            _playerData.exp = 0;
            _playerData.maxExp = 100;
            _playerData.level = 1;
        }
    }

    public void UpdateExpBar()
    {
        float newExp = (float)PlayerData.exp / (float)PlayerData.maxExp;
        _expBar.localScale = new Vector3(newExp, 1f, 1f);
    }

    public void UpdateWaterBar()
    {
        for (int i = 0; i < _waterBarElems.Count; i++)
        {
            if (i < PlayerData.thirsty)
            {
                _waterBarElems[i].gameObject.SetActive(true);
            }
            else
            {
                _waterBarElems[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddMoney(int money)
    {
        PlayerData.money += money;
    }

    public void RemoveMoney(int money)
    {
        PlayerData.money -= money;
    }

    public void AddExp(int exp)
    {
        PlayerData.exp += exp;

        if (PlayerData.exp >= PlayerData.maxExp)
        {
            PlayerData.exp -= PlayerData.maxExp;
            PlayerData.maxExp = Mathf.RoundToInt(PlayerData.maxExp * 1.75f);
            LevelUp();
        }
        UpdateExpBar();
    }

    public void LevelUp()
    {
        PlayerData.level++;
    }
}
