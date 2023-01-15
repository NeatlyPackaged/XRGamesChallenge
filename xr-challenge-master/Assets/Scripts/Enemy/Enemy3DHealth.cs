using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3DHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public int flickerAmnt;
    public float flickerDuration;
    public new Renderer renderer;

    private bool hit;

    public float resistDuration;

    public int damage;
    //public RaycastGun gunCheck;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHealth <= 0)
            Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        if(hit == false)
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

    void OnTriggerEnter(Collider other)
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

    IEnumerator WaitHit()
    {
        yield return new WaitForSeconds(resistDuration);
        hit = false;
    }

    IEnumerator DamageFlicker()
    {

        for (int i = 0; i < flickerAmnt; i++)
        {
            renderer.material.shader = Shader.Find("HDRP/Lit");
            renderer.material.SetColor("_BaseColor", Color.red);
            yield return new WaitForSeconds(flickerDuration);
            renderer.material.shader = Shader.Find("HDRP/Lit");
            renderer.material.SetColor("_BaseColor", Color.white);
            yield return new WaitForSeconds(flickerDuration);
        }

    }
}
