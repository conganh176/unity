using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficulties : MonoBehaviour
{
    public enum DifficultySelector
    {
        Easy,
        Medium,
        Hard
    }

    public DifficultySelector _currentDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        switch (_currentDifficulty)
        {
            case DifficultySelector.Easy:
                Debug.Log("You choose: Easy");
                break;
            case DifficultySelector.Medium:
                Debug.Log("You choose: Medium");
                break;
            case DifficultySelector.Hard:
                Debug.Log("You choose: Hard");
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
