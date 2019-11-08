using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    [SerializeField] float retreatDistance;

    public int health = 30;
    Rigidbody2D rigidbody;

    Transform player;
    //GameObject body;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        //body = gameObject.transform.Find("Body").gameObject;
        //sprite = body.GetComponentInChildren<SpriteRenderer>();
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

    // void Update()
    // {
    //     if (player != null)
    //     {
    //         LookAtPlayer();
    //         Move();
    //     }
        
    // }

    private void LookAtPlayer()
    {
        // var offset = 270f;
        // Vector2 direction = player.position - transform.position;
        // direction.Normalize();
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));

        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = direction;
    }

    private void Move()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {   
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            rigidbody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance
                && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        // else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        // {
        //     rigidbody.MovePosition((Vector2)transform.position + (direction * -speed * Time.deltaTime));
        // }
        
    }

    

}



