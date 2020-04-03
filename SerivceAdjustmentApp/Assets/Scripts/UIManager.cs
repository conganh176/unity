using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is null");
            }

            return _instance;
        }
    }

    public Case _activeCase;
    public GameObject _clientInfoPanel;
    public GameObject _borderPanel;
    private void Awake()
    {
        _instance = this;
    }

    public void CreateNewCase()
    {
        _activeCase = new Case();

        int randomCaseID = Random.Range(0, 1000);
        _activeCase._caseID = "" + randomCaseID;

        _clientInfoPanel.SetActive(true);
        _borderPanel.SetActive(true);
    }

    public void SummitButton()
    {
        Case newCase = new Case();
        newCase._caseID = _activeCase._caseID;
        newCase._name = _activeCase._name;
        newCase._date = _activeCase._date;
        newCase._locationNotes = _activeCase._locationNotes;
        newCase._photoTaken = _activeCase._photoTaken;
        newCase._photoNotes = _activeCase._photoNotes;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/case#" + newCase._caseID + ".dat");
        binaryFormatter.Serialize(file, newCase);
        file.Close();
    }
}
