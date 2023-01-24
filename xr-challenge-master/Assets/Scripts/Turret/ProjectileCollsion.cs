using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollsion : MonoBehaviour
{
    public float bulletLife = 0.5F;
    public int damage;
    public float resistDuration;
    public bool hit;

    void Update()
    {
        if (bulletLife > 0)
        {
            bulletLife -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // When the Projectile touches the player, it will deal damage to the player.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
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
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }

    public IEnumerator WaitHit()
    {
        yield return new WaitForSeconds(resistDuration);
        hit = false;
    }

}
