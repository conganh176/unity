using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhotoPanel : MonoBehaviour, IPanel
{
    public RawImage _photoTaken;
    public InputField _photoNotes;
    public Text _caseNumberTitle;
    public GameObject _overviewPanel;

    private string _imagePath;
    public void OnEnable()
    {
        _caseNumberTitle.text = "CASE NUMBER " + UIManager.Instance._activeCase._caseID;
    }

    public void TakePictureButton()
    {
        TakePicture(512);
    }

    private void TakePicture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize, false);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                _photoTaken.texture = texture;
                _photoTaken.gameObject.SetActive(true);
                _imagePath = path;
            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);
    }
    public void ProcessInfo()
    {
        Texture2D img = NativeCamera.LoadImageAtPath(_imagePath, 512, false);
        byte[] imgData = img.EncodeToPNG();


        UIManager.Instance._activeCase._photoTaken = imgData;
        if (string.IsNullOrWhiteSpace(_photoNotes.text) == false)
        {
            UIManager.Instance._activeCase._photoNotes = _photoNotes.text;
        }
        _overviewPanel.SetActive(true);
    }
}
