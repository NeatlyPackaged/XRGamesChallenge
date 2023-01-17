using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class PlayerHealth3D : MonoBehaviour
{

    [Header("Player Stats")]
    public int health;
    public int maxHealth = 100;
    public int flickerAmnt;
    public float flickerDuration;
    [SerializeField]
    private float launchHeight;

    [Header("Player Config")]
    public new MeshRenderer renderer;
    public Health3DBar healthBar;
    public PlayerMovement movement;

    // Similar to the enemy, this will link the health to the max health
    void Start()
    {
        health = maxHealth;
    }

    // The health bar UI will update to the health of the player
    void Update()
    {
        healthBar.SetHealth(health);
    }

    // When the Player touches the roof of the player being the Hitbox, it will cause damage to the player as well as cause the player to jump of sorts.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHitbox")
        {
            if (other.GetComponentInParent<Enemy3DHealth>() != null)
            {
                other.GetComponentInParent<Enemy3DHealth>().TakeDamage(50);
                movement._forceDirection += Vector3.up * launchHeight;
            }
        }
    }

    // Every Time the enemies/hazards deal damage it is from here. This will deal damage to the player and once the player dies it will load the losing scene
    public void TakeDamage(int damage)
    {
        StartCoroutine(DamageFlicker());
        
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    // When the player suffers damage it will flicker between two colours
    IEnumerator DamageFlicker()
    {
        for (int i = 0; i < flickerAmnt; i++)
        {
            renderer.material.color = Color.red;
            yield return new WaitForSeconds(flickerDuration);
            renderer.material.color = new Color(0.3443396f, 0.7107289f, 1, 1);
            yield return new WaitForSeconds(flickerDuration);
        }
    }

    

}
