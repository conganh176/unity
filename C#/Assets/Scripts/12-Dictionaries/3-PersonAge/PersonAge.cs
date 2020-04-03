using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAge : MonoBehaviour
{
    public Dictionary<string, int> people = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        people.Add("Alpha", 16);
        people.Add("Beta", 42);
        people.Add("Charlie", 69);

        int betaAge = people["Beta"];

        Debug.Log("Beta's age is: " + betaAge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
