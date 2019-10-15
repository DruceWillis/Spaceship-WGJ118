using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject barrel;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float fireCooldown = 1f;

    private float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootAtPlayer();
    }

    private void ShootAtPlayer()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= fireCooldown && GameObject.FindGameObjectWithTag("Player") != null)
        {
            currentTime = 0;
            GameObject bulletInstance = (GameObject)Instantiate(bullet, barrel.transform.position, transform.rotation);
            bulletInstance.transform.position = barrel.transform.position + barrel.transform.up * 0.2f;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = barrel.transform.up * bulletSpeed;
            Destroy(bulletInstance, 4f);
        }
            
    }
}
