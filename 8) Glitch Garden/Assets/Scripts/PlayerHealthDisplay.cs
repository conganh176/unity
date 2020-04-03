using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] float baseHealth = 7f;
    [SerializeField] int damage = 1;
    float health;
    TMPro.TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = baseHealth - PlayerPrefbController.GetDifficulty() * 2;
        healthText = GetComponent<TMPro.TextMeshProUGUI>();
        updateDisplay();
    }

    private void updateDisplay()
    {
        healthText.text = "HP: " + health.ToString();
    }

    public float checkHealth()
    {
        return health;
    }

    public void loseHealth()
    {
        health -= damage;
        updateDisplay();

        if (health <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
