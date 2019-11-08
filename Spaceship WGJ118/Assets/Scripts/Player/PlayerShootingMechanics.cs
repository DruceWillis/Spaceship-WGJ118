using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMechanics : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject rocketMissile;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float rocketSpeed = 15f;
    [SerializeField] float rocketCooldown = 3f;
    [SerializeField] AudioClip[] fireSounds;

    bool canShootRocket = true;
    float rocketTimer = 3f;
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
        rocketTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bulletInstance = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            bulletInstance.transform.position = transform.position + transform.up * 0.2f;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            AudioClip clip = fireSounds[0];
            GetComponent<AudioSource>().PlayOneShot(clip);
            Destroy(bulletInstance, 4f);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && (rocketTimer >= rocketCooldown))
        {
            canShootRocket = false;
            rocketTimer = 0f;
            GameObject rocketInstance = (GameObject)Instantiate(rocketMissile, transform.position, transform.rotation);
            rocketInstance.transform.position = transform.position + transform.up * 0.2f;
            rocketInstance.GetComponent<Rigidbody2D>().AddForce(transform.up * 0.1f, ForceMode2D.Force);
            //rocketInstance.GetComponent<Rigidbody2D>().velocity = barrel.transform.up * rocketSpeed;
            Destroy(rocketInstance, 4f);
        }
        
    }
}
