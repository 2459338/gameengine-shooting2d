using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShottingBoss : MonoBehaviour
{
    public GameObject bulletPrefub;
    public Transform shootingPoint;
    public float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }
    void shoot()
    {
        //íeÇê∂ê¨
        GameObject bullet = Instantiate(bulletPrefub, shootingPoint.position,Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }
}
