using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMechanics : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject barrel;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float rocketSpeed = 15f;

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
        if (gameObject.tag == "Laser Gun")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject bulletInstance = (GameObject)Instantiate(projectile, barrel.transform.position, barrel.transform.rotation);
                bulletInstance.transform.position = barrel.transform.position + barrel.transform.up * 0.2f;
                bulletInstance.GetComponent<Rigidbody2D>().velocity = barrel.transform.up * bulletSpeed;
                Destroy(bulletInstance, 4f);
            }
        }
        else if (gameObject.tag == "Rocket Launcher")
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                GameObject rocketInstance = (GameObject)Instantiate(projectile, barrel.transform.position, barrel.transform.rotation);
                rocketInstance.transform.position = barrel.transform.position + barrel.transform.up * 0.2f;
                rocketInstance.GetComponent<Rigidbody2D>().AddForce(barrel.transform.up * 0.1f, ForceMode2D.Force);
                //rocketInstance.GetComponent<Rigidbody2D>().velocity = barrel.transform.up * rocketSpeed;
                Destroy(rocketInstance, 4f);
            }
        }
        
    }
}
