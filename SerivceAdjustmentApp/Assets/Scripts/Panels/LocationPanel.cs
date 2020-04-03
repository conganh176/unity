using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LocationPanel : MonoBehaviour, IPanel
{
    public RawImage _mapImage;
    public InputField _mapNotes;
    public Text _caseNumberText;

    public string _apiKey;
    public float _xCord, _yCord;
    public int _zoom;
    public int _imageSize;
    public string _url = "https://api.mapbox.com/styles/v1/mapbox/streets-v11/static/";

    public void OnEnable()
    {
        _caseNumberText.text = "CASE NUMBER " + UIManager.Instance._activeCase._caseID;
    }

    public void Start()
    {
        StartCoroutine(LocationService());
        StartCoroutine(GetLocationRoutine());
    }

    IEnumerator LocationService()
    {
        if (Input.location.isEnabledByUser == true)
        {
            Input.location.Start();

            int maxWaitingTime = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWaitingTime > 0)
            {
                yield return new WaitForSeconds(1.0f);
                maxWaitingTime--;
            }

            if (maxWaitingTime < 1)
            {
                Debug.Log("Time Out");
                yield break;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device's location");
            }
            else
            {
                _xCord = Input.location.lastData.latitude;
                _yCord = Input.location.lastData.longitude;
            }

            Input.location.Stop();
        }
    }

    IEnumerator GetLocationRoutine()
    {
        _url += _xCord + "," + _yCord + "," + _zoom + "/" + _imageSize + "x" + _imageSize + "?access_token=" + _apiKey;

        UnityWebRequest map = UnityWebRequestTexture.GetTexture(_url);

        yield return map.SendWebRequest();

        if (map.isNetworkError || map.isHttpError)
        {
            Debug.LogError("Map error: " + map.error);
        }
        else
        {
            _mapImage.texture = ((DownloadHandlerTexture)map.downloadHandler).texture;
        }
    }

    public void ProcessInfo()
    {
        if (string.IsNullOrWhiteSpace(_mapNotes.text) == false)
        {
            UIManager.Instance._activeCase._locationNotes = _mapNotes.text;
        }
    }
}
