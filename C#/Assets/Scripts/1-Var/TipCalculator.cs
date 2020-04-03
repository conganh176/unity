using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float bill = 39.99f;
    [SerializeField] private float tipPercent = 20.00f;
    private float total;
    void Start()
    {
        float tipAmount = bill * (tipPercent / 100);
        Debug.Log("Bill is " + bill + " and tip is " + tipAmount);
        total = bill + tipAmount;
        Debug.Log("So your total is: " + total);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
