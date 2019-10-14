using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{  
    [SerializeField] ParticleSystem explosionVFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Projectile")
        {
            if (gameObject.tag == "Player")
            {
                FindObjectOfType<PlayerController>().health -= 10;
                if (FindObjectOfType<PlayerController>().health <= 0)
                {
                    ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
            else
            {
                FindObjectOfType<EnemyController>().health -= 10;
                if (FindObjectOfType<EnemyController>().health <= 0)
                {
                    ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }

        
    }
}