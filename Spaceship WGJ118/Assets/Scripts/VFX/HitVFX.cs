using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
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
        Destroy(gameObject);
        Instantiate(hitEffect, transform.position, transform.rotation);
        if (explosionVFX != null)
        {
            Instantiate(explosionVFX, transform.position, transform.rotation);
        }
        //Instantiate
    }
}
