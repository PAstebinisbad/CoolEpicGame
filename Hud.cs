using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public Text healthText; // Drag UI Text here in the Inspector
    public HealthSystem playerHealth; // Drag player's HealthSystem here in the Inspector

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "Health: " + playerHealth.GetCurrentHealth() + "/" + playerHealth.GetMaxHealth();
        }
    }
}

