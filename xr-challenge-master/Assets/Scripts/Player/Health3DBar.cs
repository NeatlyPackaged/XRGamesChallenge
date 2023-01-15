using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health3DBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealth3D playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth3D>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}

