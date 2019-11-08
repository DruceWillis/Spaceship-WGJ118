using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KamikazeController : MonoBehaviour
{

    [SerializeField] float speed = 15f;

    public int health = 10;
    Rigidbody2D rigidbody;

    Transform player;
    //GameObject body;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            LookAtPlayer();
            Move();
        }
        
    }

    private void LookAtPlayer()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = direction;
    }

    private void Move()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        rigidbody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
