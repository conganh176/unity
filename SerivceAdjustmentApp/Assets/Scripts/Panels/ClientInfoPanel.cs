using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoPanel : MonoBehaviour, IPanel
{
    public Text _caseNumberText;
    public InputField _firstName, _lastName;
    public GameObject _locationPanel;

    public void OnEnable()
    {
        _caseNumberText.text = "CASE NUMBER " + UIManager.Instance._activeCase._caseID;
    }
    public void ProcessInfo()
    {
        if (string.IsNullOrWhiteSpace(_firstName.text) || string.IsNullOrWhiteSpace(_lastName.text))
        {
            Debug.Log("First Name or Last Name is empty");
        }
        else
        {
            UIManager.Instance._activeCase._name = _firstName.text + " " + _lastName.text;
            _locationPanel.SetActive(true);
        }
    }
}
