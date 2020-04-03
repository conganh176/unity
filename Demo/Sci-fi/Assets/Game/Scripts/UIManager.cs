using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    [SerializeField] private GameObject _coinImage;
    public void UpdateAmmo(int ammo)
    {
        _ammoText.text = "Ammo: " + ammo;
    }

    public void CollectCoin()
    {
        _coinImage.SetActive(true);
    }

    public void RemoveCoin()
    {
        _coinImage.SetActive(false);
    }
}
