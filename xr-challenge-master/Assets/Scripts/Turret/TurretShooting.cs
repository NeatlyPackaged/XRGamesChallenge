using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject projectile;
    public GameObject firePoint;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public float launchVelocity = 700f;

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject ball = Instantiate(projectile, firePoint.transform.position,firePoint.transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        }
    }
}
