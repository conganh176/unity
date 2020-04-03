using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string name = "Kongu Anfu";
    [SerializeField] private int age = 23;
    [SerializeField] private float speed = 10.5f;
    [SerializeField] private int health = 100;
    [SerializeField] private int score = 100;
    [SerializeField] private bool hasAllKeys = false;
    [SerializeField] private int ammo = 69;
    void Start()
    {
        Debug.Log("My name is " + name + ". I am " + age + " years old.'");
        Debug.Log("Speed: " + speed);
        Debug.Log("Health: " + health);
        Debug.Log("Score: " + score);
        Debug.Log("Has All Keys: " + hasAllKeys);
        Debug.Log("Ammo: " + ammo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
