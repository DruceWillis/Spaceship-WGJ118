﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMechanics : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject barrel;
    [SerializeField] float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bulletInstance = (GameObject)Instantiate(bullet, barrel.transform.position, transform.rotation);
            bulletInstance.transform.position = barrel.transform.position + barrel.transform.up * 0.2f;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = barrel.transform.up * bulletSpeed;
            Destroy(bulletInstance, 4f);
        }
    }
}
