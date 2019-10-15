using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;

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
        ParticleSystem particles = Instantiate(hitEffect, transform.position, transform.rotation);
    }
}
