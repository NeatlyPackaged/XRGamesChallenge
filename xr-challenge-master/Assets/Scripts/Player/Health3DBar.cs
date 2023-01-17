using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health3DBar : MonoBehaviour
{
    [Header("Config")]
    public Slider healthBar;
    public PlayerHealth3D playerHealth;

    // On start, the health bar will locate the player health and will assign itself to the health float
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth3D>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }

    // On every moment health gets changed, it will change the health bar
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}

