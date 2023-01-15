using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class PlayerHealth3D : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public new MeshRenderer renderer;
    public int flickerAmnt;
    public float flickerDuration;

    public Health3DBar healthBar;

    //public RaycastGun gunCheck;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        //healthBar.SetHealth(health);
    }

    void Update()
    {
        
        healthBar.SetHealth(health);
    }
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        
        //healthBar.SetHealth(health);
        StartCoroutine(DamageFlicker());
        
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
            //Destroy(gameObject);
        }
    }

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
