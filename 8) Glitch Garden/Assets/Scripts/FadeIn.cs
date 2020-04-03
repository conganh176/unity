using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] float fadeInTime = 1f;
    Image fadePanel;
    Color currentColor = Color.black;
    
    // Start is called before the first frame update
    void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            DoFadeIn();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void DoFadeIn()
    {
        float alphaChange = Time.deltaTime / fadeInTime;
        currentColor.a -= alphaChange;
        fadePanel.color = currentColor;
    }
}
