using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3DHealth : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int health;
    public int maxHealth = 100;
    public int flickerAmnt;
    public float flickerDuration;
    public float resistDuration_Player_Enemy;
    public int damage;

    [Header("Enemy Config")]
    public new Renderer renderer;
    public bool hit;

    // This will initialise the health variable to be the maxhealth variable you will start with
    void Start()
    {
        health = maxHealth;
    }

    // Once the player has lost all health then it will destroy // Could improve in future by calling an event to cause particles and sound effects to play when dying
    void Update()
    {
        if (maxHealth <= 0)
            Destroy(this.gameObject);
    }

    // This will be called via the player and the value is assigned based of the damage variable in the player script, this will also buffer damage to create a sort of damage resist, when health = 0 then die
    public void TakeDamage(int damage)
    {
        if (hit == false)
        {

            StartCoroutine(DamageFlicker());
            health -= damage;
            hit = true;
            StartCoroutine(WaitHit());
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // When the enemy touches the player it will cause damage to the player and will call the wait hit event here to allow the player to have a resists too
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("HitP");

            if (other.GetComponent<PlayerHealth3D>() != null)
            {
                
                if (hit == false)
                {
                    //Debug.Log("hit");
                    other.GetComponent<PlayerHealth3D>().TakeDamage(damage);
                    hit = true;
                    StartCoroutine(WaitHit());
                }
            }
        }
    }

    // WHile the player remains in the collision it will deal damage to prevent you sticking onto the enemy to avoid more damage
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("HitP");

            if (other.GetComponent<PlayerHealth3D>() != null)
            {

                if (hit == false)
                {
                    //Debug.Log("hit");
                    other.GetComponent<PlayerHealth3D>().TakeDamage(damage);
                    hit = true;
                    StartCoroutine(WaitHit());
                }
            }
        }
    }

    // This is called above to prevent more damage from being applied
    public IEnumerator WaitHit()
    {
        yield return new WaitForSeconds(resistDuration_Player_Enemy);
        hit = false;
    }

    //When the object gets damaged it will flicker between two colours
    IEnumerator DamageFlicker()
    {

        for (int i = 0; i < flickerAmnt; i++)
        {
            renderer.material.color = Color.white;
            yield return new WaitForSeconds(flickerDuration);
            renderer.material.color = Color.red;
            yield return new WaitForSeconds(flickerDuration);

        }
    }
}

