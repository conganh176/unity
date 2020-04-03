using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDatabase : MonoBehaviour
{
    Customer Kongu;
    Customer Dan;
    Customer Danna;
    // Start is called before the first frame update
    void Start()
    {
        Kongu = new Customer("Kongu", "Anfu", 23, "Male", "Student");
        Dan = new Customer("Daniel", "Denlion", 24, "Male", "Gamer");
        Danna = new Customer("Danna", "", 20, "Female", "Student");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
