using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{  
    [SerializeField] ParticleSystem explosionVFX;
    [SerializeField] AudioClip explosionSFX;
    // Start is called before the first frame update

    int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Projectile")
            damage = 10;
        
        if (other.gameObject.tag == "Rocket")
            damage = 30;

        if (gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerController>().health -= damage;
            if (FindObjectOfType<PlayerController>().health <= 0)
            {
                ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(explosionSFX, gameObject.transform.position);
                Destroy(gameObject);
                Time.timeScale = 0.2f;
            }
            
        }
        else if (gameObject.tag == "Enemy")
        {
            FindObjectOfType<EnemyController>().health -= damage;
            if (FindObjectOfType<EnemyController>().health <= 0)
            {
                ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(explosionSFX, gameObject.transform.position);
                Destroy(gameObject);
            }
            
        }
        else if (gameObject.tag == "Kamikaze")
        {
            FindObjectOfType<KamikazeController>().health -= damage;

            if (FindObjectOfType<KamikazeController>().health <= 0)
            {
                ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(explosionSFX, gameObject.transform.position);
                Destroy(gameObject);
            }
        }
        
        // if (other.gameObject.tag == "Projectile")
        // {
        //     if (gameObject.tag == "Player")
        //     {
        //         FindObjectOfType<PlayerController>().health -= 10;
        //         if (FindObjectOfType<PlayerController>().health <= 0)
        //         {
        //             ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
        //             AudioSource.PlayClipAtPoint(explosionSFX, gameObject.transform.position);
        //             Destroy(gameObject);
        //             Time.timeScale = 0.2f;
        //         }
                
        //     }
        //     else if (gameObject.tag == "Enemy")
        //     {
        //         FindObjectOfType<EnemyController>().health -= 10;
        //         if (FindObjectOfType<EnemyController>().health <= 0)
        //         {
        //             ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
        //             AudioSource.PlayClipAtPoint(explosionSFX, gameObject.transform.position);
        //             Destroy(gameObject);
        //         }
                
        //     }
        //     else if (gameObject.tag == "Kamikaze")
        //     {
        //         FindObjectOfType<KamikazeController>().health -= 10;

        //         if (FindObjectOfType<KamikazeController>().health <= 0)
        //         {
        //             ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
        //             AudioSource.PlayClipAtPoint(explosionSFX, gameObject.transform.position);
        //             Destroy(gameObject);
        //         }
        //     }
        // }      

        if (other.gameObject.tag == "Kamikaze")
        {
            if (gameObject.tag == "Player")
            {
                FindObjectOfType<PlayerController>().health -= 40;
                Destroy(other.gameObject);
                ParticleSystem kamikazeExplosion = Instantiate(explosionVFX, Vector2.Lerp(other.transform.position, transform.position, 0.5f), transform.rotation);
                if (FindObjectOfType<PlayerController>().health <= 0)
                {
                    ParticleSystem particles = Instantiate(explosionVFX, transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(explosionSFX, gameObject.transform.position);
                    Destroy(gameObject);
                    Time.timeScale = 0.2f;
                }
                
            }
        }
    }
}