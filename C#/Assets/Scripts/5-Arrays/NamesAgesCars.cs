using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamesAgesCars : MonoBehaviour
{
    [SerializeField] private string[] names = new string[] { "Abby", "Billy", "Charlie"};
    [SerializeField] private int[] ages = new int[] {9, 18, 27};
    [SerializeField] private string[] cars = new string[] { "Not car", "Honda Maybe", "Ferrari" };

    [SerializeField] private int randomId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomId = Random.Range(0, names.Length);
            Debug.Log("Name: " + names[randomId] + ". Age: " + ages[randomId] + ". Car: " + cars[randomId]);
        }   
    }
}
