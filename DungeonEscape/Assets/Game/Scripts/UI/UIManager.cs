using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get 
        {
            if (_instance == null)
                Debug.LogError("UI Manager is null");

            return _instance;
        }
    }

    [SerializeField] private Text _playerGemText;
    [SerializeField] private Image _selectionImage;
    [SerializeField] private Text _gemCountText;
    [SerializeField] private Image[] _healthBar;

    public void OpenShop(int gem)
    {
        _playerGemText.text = "Gems: " + gem.ToString();
    }

    public void UpdateShopSelection(float yPosition)
    {
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, yPosition);
    }

    public void UpdateGemCount(int gem)
    {
        _gemCountText.text = gem.ToString();
    }

    public void UpdateLives(int lives)
    {
        for (int i = 0; i <= lives; i++)
        {
            if (i == lives)
            {
                _healthBar[i].enabled = false;
            }
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
