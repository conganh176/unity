using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string itemName = "Excalibur";
    [SerializeField] private string itemDescription = "A Sword";
    [SerializeField] private Sprite icon;
    [SerializeField] private float attackStrength = 69.69f;
    void Start()
    {
        Debug.Log("Name: " + itemName);
        Debug.Log("Description: " + itemDescription);
        Debug.Log("Attack: " + attackStrength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
