using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private int _currentItemID;
    private int _currentItemCost;
    private Player _player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = collision.GetComponent<Player>();
            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player._gems);
            }

            _shopPanel.SetActive(true);
            _currentItemID = 1;
            _currentItemCost = 200;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int itemID)
    {
        switch(itemID)
        {
            case 0:
                {
                    UIManager.Instance.UpdateShopSelection(74f);
                    _currentItemID = 0;
                    _currentItemCost = 200;
                    break;
                }
            case 1:
                {
                    UIManager.Instance.UpdateShopSelection(-26f);
                    _currentItemID = 1;
                    _currentItemCost = 400;
                    break;
                }
            case 2:
                {
                    UIManager.Instance.UpdateShopSelection(-126f);
                    _currentItemID = 2;
                    _currentItemCost = 100;
                    break;
                }
        }
    }

    public void Buy()
    {
        if (_player._gems >= _currentItemCost)
        {
            if (_currentItemID == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            _player._gems -= _currentItemCost;
            Debug.Log("Purchase: " + _currentItemID);
            Debug.Log("Remain: " + _player._gems);
        }
        else
        {
            Debug.Log("Not enough gems!!!");
        }
    }
}
