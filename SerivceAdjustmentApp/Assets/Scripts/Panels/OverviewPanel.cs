using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class OverviewPanel : MonoBehaviour, IPanel
{
    public Text _caseNumberTitle;
    public Text _nameTitle;
    public Text _dateTitle;
    public Text _locationNotes;
    public RawImage _photoTaken;
    public Text _photoNotes;

    public void OnEnable()
    {
        _caseNumberTitle.text = "CASE NUMBER " + UIManager.Instance._activeCase._caseID;
        _nameTitle.text = UIManager.Instance._activeCase._name;
        _dateTitle.text = DateTime.Today.ToString();
        _locationNotes.text = "LOCATION NOTES:\n" + UIManager.Instance._activeCase._locationNotes;

        Texture2D reconstructedImage = new Texture2D(1, 1);
        reconstructedImage.LoadImage(UIManager.Instance._activeCase._photoTaken);

        _photoTaken.texture = (Texture) reconstructedImage;
        _photoNotes.text = "PHOTO NOTES:\n" + UIManager.Instance._activeCase._photoNotes;
    }
    public void ProcessInfo()
    {

    }
}
