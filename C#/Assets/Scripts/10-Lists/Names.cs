using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Names : MonoBehaviour
{
    public List<string> names = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(var name in names)
        {
            Debug.Log(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var nameToBeRemoved = names[Random.Range(0, names.Count)];
            Debug.Log("Name to be removed: " + nameToBeRemoved);
            names.Remove(nameToBeRemoved);

            foreach (var name in names)
            {
                Debug.Log(name);
            }
        }
    }
}
